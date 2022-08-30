using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    Bounds bounds;

    void Awake(){
        bounds = GetComponent<BoxCollider2D>().bounds;
    }

    void OnTriggerExit2D(Collider2D other) {
        Head snakeHead = other.GetComponent<Head>();
        if(snakeHead == null)
            return;
        Vector3 snakePosition = snakeHead.transform.position;
        if(snakePosition.x > bounds.max.x)
            snakeHead.transform.position = new Vector2(bounds.min.x, snakePosition.y);
        else if(snakePosition.x < bounds.min.x)
            snakeHead.transform.position = new Vector2(bounds.max.x, snakePosition.y);
        else if(snakePosition.y > bounds.max.y)
            snakeHead.transform.position = new Vector2(snakePosition.x, bounds.min.y);
        else if(snakePosition.y < bounds.min.y)
            snakeHead.transform.position = new Vector2(snakePosition.x, bounds.max.y);
    }
}
