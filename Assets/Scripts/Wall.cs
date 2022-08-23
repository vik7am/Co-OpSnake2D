using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    enum Direction{UP, DOWN, LEFT, RIGHT};
    [SerializeField]Direction direction;

    /*private void OnTriggerEnter2D(Collider2D other) {
        SnakeMovement snake = other.GetComponent<SnakeMovement>();
        if(snake ==null)
            return;
        switch(direction){
            case Direction.UP :
            snake.transform.position = new Vector2(snake.transform.position.x, -(snake.transform.position.y-1));
            break;
            case Direction.DOWN : 
            snake.transform.position = new Vector2(snake.transform.position.x, -(snake.transform.position.y+1));
            break;
            case Direction.LEFT :
            snake.transform.position = new Vector2(-(snake.transform.position.x+1), snake.transform.position.y);
            break;
            case Direction.RIGHT :
            snake.transform.position = new Vector2(-(snake.transform.position.x-1), snake.transform.position.y);
            break;
        }
    }*/
}
