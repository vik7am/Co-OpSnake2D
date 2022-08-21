using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;

    private void Awake() {
        eggSpawner = GetComponentInParent<EggSpawner>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        SnakeMovement snake = collision.GetComponent<SnakeMovement>();
        if (snake == null)
            return;
        eggSpawner.SpawnEgg();
        snake.IncreseLength();
    }
}
