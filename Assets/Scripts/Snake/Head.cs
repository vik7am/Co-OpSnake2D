using UnityEngine;

public class Head : MonoBehaviour
{
    SnakeController snakeController;
    void Awake(){
        snakeController = GetComponentInParent<SnakeController>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Body snakeBody = other.GetComponent<Body>();
        if(snakeBody != null){
            snakeBody.KillBody();
        }
    }
}
