using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] int initialSnakeLength;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] GamePauseUI gamePauseUI;
    Snake snake;
    Movement movement;
    Health health;
    ScoreManager scoreManager;
    SpecialAbilityManager managerSA;

    private void Awake() {
        snake = new Snake();
        movement = GetComponent<Movement>();
        health = GetComponent<Health>();
        scoreManager = GetComponent<ScoreManager>();
        managerSA = GetComponent<SpecialAbilityManager>();
        
    }

    void Start()
    {
        snake.body.Add(transform);
        movement.setSnake(snake);
        health.setSnake(snake);
        managerSA.setSnake(snake);
        health.CreateBody();
        health.IncreseLength(initialSnakeLength - 1);
        //managerSA.activateSpecialAbility(SpecialAbility.SHIELD);
        movement.StartMovement();
    }

    private void Update()
    {
        PaueGameInput();
    }

    void PaueGameInput(){
        if(!health.IsAlive())
            return;
        if(Input.GetKeyDown(KeyCode.Escape)){
            movement.StopMovement();
            gamePauseUI.gameObject.SetActive(true);
        }
    }

    public void ActivateSA(SpecialAbility specialAbility){
        managerSA.activateSpecialAbility(specialAbility);
    }

    public void ResumeGame(){
        gamePauseUI.gameObject.SetActive(false);
        movement.StartMovement();
    }

    public void KillSnake(){
        if(managerSA.specialAbilityStatus(SpecialAbility.SHIELD))
            return;
        health.KillSnake();
        movement.StopMovement();
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.ShowWinner(scoreManager.GetSnakeType());
    }

    public void IncreseLength(int length){
        health.IncreseLength(length);
    }

    public void DecreaseLength(int length){
        health.DecreaseLength(length);
    }

    public void IncreseScore(int score){
        if(managerSA.specialAbilityStatus(SpecialAbility.SCORE_BOOST))
            score = managerSA.GetSpecialScore(score);
        scoreManager.IncreseScore(score);
    }

    public void UpdateSpeed(){
        movement.SpeedBoost(managerSA.GetSpeedMultiplier());
    }
}
