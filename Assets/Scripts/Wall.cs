using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        SnakeMovement snake = other.GetComponent<SnakeMovement>();
        if(snake ==null)
            return;
        snake.KillSnake();
    }
}
