using UnityEngine;

public class Body : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        SnakeController snake = other.GetComponent<SnakeController>();
        if(snake ==null)
            return;
        snake.KillSnake();
    }
}
