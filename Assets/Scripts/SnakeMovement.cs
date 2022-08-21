using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    bool alive;
    Vector3 direction;
    int snakeLength = 3;
    List<Transform> snake;
    [SerializeField] GameObject tailPrefab;

    void Start()
    {
        SpawnSnake();
        StartCoroutine(GameLoop());
    }

    private void SpawnSnake()
    {
        alive = true;
        direction = Vector3.right;
        snake = new List<Transform>();
        snake.Add(this.transform);
        for (int i = 0; i < snakeLength; i++)
            snake.Add(Instantiate(tailPrefab).transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            direction = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.W))
            direction = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.S))
            direction = Vector3.down;
    }

    IEnumerator GameLoop()
    {
        while (alive)
        {
            for (int i = 1; i < snake.Count ; i++)
                snake[snake.Count -i].position = snake[snake.Count -(i+1)].position;
            transform.position += direction;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void IncreseLength(){
        snake.Add(Instantiate(tailPrefab, snake[snake.Count -1].position, Quaternion.identity).transform);
    }

    public void KillSnake(){
        alive = false;
    }
}
