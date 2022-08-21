using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] Transform egg;
    [SerializeField] BoxCollider2D box;
    [SerializeField] ScoreUI scoreUI;
    Bounds bounds;

    void Start()
    {
        bounds = box.bounds;
        box.gameObject.SetActive(false);
        SpawnEgg();
    }

    public void SpawnEgg()
    {
        int x = (int)Random.Range(bounds.min.x, bounds.max.x);
        int y = (int)Random.Range(bounds.min.y, bounds.max.y);
        egg.position = new Vector3(x, y, 0);
    }

    public void IncreseScore(int score){
        scoreUI.UpdateScore(score);
    }
}
