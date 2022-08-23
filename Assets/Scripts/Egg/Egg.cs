using UnityEngine;

public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;
    [SerializeField] int score;

    private void Awake() {
        eggSpawner = GetComponentInParent<EggSpawner>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        SnakeController snake = collision.GetComponent<SnakeController>();
        if (snake == null)
            return;
        snake.IncreseScore(score);
        eggSpawner.SpawnEgg();
        snake.IncreseLength(1);
    }
}
