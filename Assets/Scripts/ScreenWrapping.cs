using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    Bounds bounds;

    void Awake()
    {
        bounds = GetComponent<BoxCollider2D>().bounds;
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        SnakeMovement snake = other.GetComponent<SnakeMovement>();
        if(snake == null)
            return;
        if(snake.transform.position.x > bounds.max.x)
            snake.transform.position = new Vector2(bounds.min.x, snake.transform.position.y);
        else if(snake.transform.position.x < bounds.min.x)
            snake.transform.position = new Vector2(bounds.max.x, snake.transform.position.y);
        else if(snake.transform.position.y > bounds.max.y)
            snake.transform.position = new Vector2(snake.transform.position.x, bounds.min.y);
        else if(snake.transform.position.y < bounds.min.y)
            snake.transform.position = new Vector2(snake.transform.position.x, bounds.max.y);
    }
}
