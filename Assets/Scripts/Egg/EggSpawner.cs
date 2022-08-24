using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] Egg egg;
    [SerializeField] BoxCollider2D box;
    EggType spawnEggType;
    bool criticalState;
    Bounds bounds;

    void Start()
    {
        bounds = box.bounds;
        SpawnEgg();
    }

    public void SetCriticalState(bool state){
        criticalState = state;
    }

    public void SpawnEgg()
    {
        int x = (int)Random.Range(bounds.min.x, bounds.max.x);
        int y = (int)Random.Range(bounds.min.y, bounds.max.y);
        egg.transform.position = new Vector3(x, y, 0);
        if(criticalState)
            spawnEggType = EggType.MASS_GAINER;
        else
            spawnEggType = (EggType)Random.Range(0,2);
        egg.SetEggType(spawnEggType);
    }
}
