using UnityEngine;

public class Body : MonoBehaviour
{
    public void KillBody(){
        SnakeController snakeController = GetComponentInParent<SnakeController>();
        if(snakeController == null)
            return;
        snakeController.KillSnake();
    }
}
