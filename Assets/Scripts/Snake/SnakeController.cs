using System.Collections.Generic;
using UnityEngine;

public class Snake
{
    public List<Transform> body;
    public Snake()
    {
        body = new List<Transform>();
    }
}

public class SnakeController : MonoBehaviour
{
    [SerializeField] int initialSnakeLength;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] GamePauseUI gamePauseUI;
    Snake snake;
    Movement movement;
    Health health;
    ScoreManager scoreManager;

    private void Awake() {
        snake = new Snake();
        snake.body.Add(transform);
        movement = GetComponent<Movement>();
        health = GetComponent<Health>();
        scoreManager = GetComponent<ScoreManager>();
        movement.setSnake(snake);
        health.setSnake(snake);
        health.IncreseLength(initialSnakeLength);
    }

    void Start()
    {
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

    public void ResumeGame(){
        gamePauseUI.gameObject.SetActive(false);
        movement.StartMovement();
    }

    public void KillSnake(){
        health.KillSnake();
        movement.StopMovement();
        gameOverUI.gameObject.SetActive(true);
    }

    public void IncreseLength(int length){
        health.IncreseLength(length);
    }

    public void IncreseScore(int score){
        scoreManager.IncreseScore(score);
    }
}
