using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] Body snakeBody;
    [SerializeField] Movement movement;
    [SerializeField] int snakeLength;
    Snake snake;
    SpecialAbilityManager managerSA;

    private void Awake() {
        snake = new Snake();
        managerSA = GetComponent<SpecialAbilityManager>();
    }

    void Start()
    {
        snake.body.Add(movement.transform);
        CreateBody();
        movement.setSnake(snake);
        managerSA.setSnake(snake);
        movement.StartMovement();
    }

    void CreateBody(){
        for(int i = 0; i < snakeLength; i++){
            Vector3 bodyPostion = snake.body[i].position - Vector3.right;
            Body body = Instantiate(snakeBody, bodyPostion, Quaternion.identity);
            body.transform.SetParent(transform);
            snake.body.Add(body.transform);
        }
    }

    public void IncreseLength(int length){
        for (int i = 0; i < length; i++){
            Body body = Instantiate(snakeBody, snake.body[snake.body.Count -1].position, Quaternion.identity);
            body.transform.SetParent(transform);
            snake.body.Add(body.transform);
        }
        if(managerSA.specialAbilityStatus(SpecialAbility.DISABLED))
            return;
        managerSA.UpdateSAColor();
    }

    public void DecreaseLength(int length){
        for (int i = 0; i < length; i++){
            Destroy(snake.body[snake.body.Count-1].gameObject);
            snake.body.RemoveAt(snake.body.Count-1);
        }
    }

    public void ActivateSA(SpecialAbility specialAbility){
        managerSA.activateSpecialAbility(specialAbility);
    }

    public void KillSnake(){
        if(managerSA.specialAbilityStatus(SpecialAbility.SHIELD))
            return;
        GameManager.Instance().GameOver();
    }

    public void IncreseScore(int score){
        if(managerSA.specialAbilityStatus(SpecialAbility.SCORE_BOOST))
            score = managerSA.GetSpecialScore(score);
        GameManager.Instance().UpdateScore(score);
    }

    public bool CriticalState(){
        return (snake.body.Count <= snakeLength);
    }

    public void UpdateSpeed(){
        movement.UpdateMovementSpeed(managerSA.GetSpeedMultiplier());
    }

    public void StopSnake(){
        movement.StopMovement();
    }

    public void StartSnake(){
        movement.StartMovement();
    }
}
