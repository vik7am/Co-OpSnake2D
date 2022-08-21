using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    bool alive;
    Vector3 direction;
    Vector3 previousDirection;
    bool horizontalMovement;
    int snakeLength = 3;
    List<Transform> snake;
    [SerializeField] GameObject tailPrefab;
    [SerializeField] GameOverUI gameOverUI;

    void Start()
    {
        SpawnSnake();
        StartCoroutine(GameLoop());
    }

    private void SpawnSnake()
    {
        alive = true;
        horizontalMovement = true;
        direction = Vector3.right;
        previousDirection = direction;
        snake = new List<Transform>();
        snake.Add(this.transform);
        for (int i = 0; i < snakeLength; i++)
            snake.Add(Instantiate(tailPrefab).transform);
    }

    private void Update()
    {
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
        while (alive)
        {
            for (int i = 1; i < snake.Count ; i++)
                snake[snake.Count -i].position = snake[snake.Count -(i+1)].position;
            transform.position += direction;
            if(previousDirection != direction){
                horizontalMovement = !horizontalMovement;
                previousDirection = direction;
            }
            yield return new WaitForSeconds(0.25f);
            
        }
    }

    public void IncreseLength(){
        snake.Add(Instantiate(tailPrefab, snake[snake.Count -1].position, Quaternion.identity).transform);
    }

    public void KillSnake(){
        alive = false;
        gameOverUI.gameObject.SetActive(true);
    }
}
