using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 direction;
    Vector3 previousDirection;
    Coroutine coroutine;
    Snake snake;
    bool horizontalMovement;
    bool snakeMovement;
    float waitDuration;
    [Range(1,20)]
    [SerializeField] int speed;
    [SerializeField]bool alternateInput;
    [SerializeField]bool disableInput;

    void Awake() {
        direction = Vector2.right;
    }

    void Start() {
        waitDuration = 1.0f/speed;
    }

    void Update()
    {
        if(disableInput)
            return;
        if(!snakeMovement)
            return;
        if(alternateInput)
            MovementInputAlternate();
        else
            MovementInputNormal();
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

    public void UpdateMovementSpeed(float speedBoost){
        waitDuration = 1.0f/(speed * speedBoost);
    }

    // horizontalmovement flag ignores same or opposite direction inputs
    // to prevent snake from rotating 180 degree.
    void MovementInputNormal(){
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

    void MovementInputAlternate(){
        if(horizontalMovement){
            if (Input.GetKeyDown(KeyCode.UpArrow))
                direction = Vector3.up;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                direction = Vector3.down;
        }
        else{
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                direction = Vector3.right;
        }
    }

    IEnumerator GameLoop()
    {
        while (snakeMovement)
        {
            int snakeSize = snake.body.Count;
            for (int i = 1; i < snakeSize; i++)
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
