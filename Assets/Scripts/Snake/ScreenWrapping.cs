using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    Bounds bounds;
    [SerializeField]BoxCollider2D box;

    void Awake(){
        bounds = box.GetComponent<BoxCollider2D>().bounds;
    }

    void OnTriggerExit2D(Collider2D other) {
        if(transform.position.x > bounds.max.x)
            transform.position = new Vector2(bounds.min.x, transform.position.y);
        else if(transform.position.x < bounds.min.x)
            transform.position = new Vector2(bounds.max.x, transform.position.y);
        else if(transform.position.y > bounds.max.y)
            transform.position = new Vector2(transform.position.x, bounds.min.y);
        else if(transform.position.y < bounds.min.y)
            transform.position = new Vector2(transform.position.x, bounds.max.y);
    }
}
