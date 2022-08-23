using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] Transform egg;
    [SerializeField] BoxCollider2D box;
    Bounds bounds;

    void Start()
    {
        bounds = box.bounds;
        SpawnEgg();
    }

    public void SpawnEgg()
    {
        int x = (int)Random.Range(bounds.min.x, bounds.max.x);
        int y = (int)Random.Range(bounds.min.y, bounds.max.y);
        egg.position = new Vector3(x, y, 0);
    }
}
