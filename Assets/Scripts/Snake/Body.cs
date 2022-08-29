using UnityEngine;

public class Body : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        SnakeController snakeController = other.GetComponentInParent<SnakeController>();
        if(snakeController == null)
            return;
        snakeController.KillSnake();
    }
}
