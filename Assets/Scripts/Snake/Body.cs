using UnityEngine;

public class Body : MonoBehaviour
{
    SnakeController snakeController;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<SnakeController>() == null)
            return;
        snakeController.GetComponent<SnakeController>().KillSnake();
    }

    public void SetParent(SnakeController snakeController){
        this.snakeController = snakeController;
    }
}
