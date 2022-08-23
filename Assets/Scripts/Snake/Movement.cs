using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1,20)]
    [SerializeField] int speed;
    Vector3 direction;
    Vector3 previousDirection;
    Coroutine coroutine;
    Snake snake;
    bool horizontalMovement;
    bool snakeMovement;
    float waitDuration;

    private void Start() {
        direction = Vector2.right;
        waitDuration = 1.0f/speed;
    }

    private void Update()
    {
        if(!snakeMovement)
            return;
        MovementDirectionInput();
    }

    public void StartMovement(){
        snakeMovement = true;
        if(coroutine == null)
            StartCoroutine(GameLoop());
    }

    public void StopMovement(){
        snakeMovement = false;
    }

    public void setSnake(Snake snake){
        this.snake = snake;
    }

    void MovementDirectionInput(){
        if(horizontalMovement){
            if (Input.GetKeyDown(KeyCode.W))
                direction = Vector3.up;
            else if (Input.GetKeyDown(KeyCode.S))
                direction = Vector3.down;
        }
        else{
            if (Input.GetKeyDown(KeyCode.A))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D))
                direction = Vector3.right;
        }
    }

    IEnumerator GameLoop()
    {
        while (snakeMovement)
        {
            int snakeSize = snake.body.Count;
            for (int i = 1; i < snakeSize ; i++)
                snake.body[snakeSize -i].position = snake.body[snakeSize -(i+1)].position;
            transform.position += direction;
            if(previousDirection != direction){
                horizontalMovement = !horizontalMovement;
                previousDirection = direction;
            }
            yield return new WaitForSeconds(waitDuration);
        }
        coroutine = null;
    }
}
