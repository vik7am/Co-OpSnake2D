using UnityEngine;

public class Body : MonoBehaviour
{
    //SnakeController snakeController;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponentInParent<SnakeController>() == null)
            return;
        GetComponentInParent<SnakeController>().KillSnake();
    }

    /*private void Awake() {
        snakeController = GetComponentInParent<SnakeController>();
    }*/

    /*public void SetParent(SnakeController snakeController){
        this.snakeController = snakeController;
    }*/
}
