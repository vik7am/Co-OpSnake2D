using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] Egg egg;
    [SerializeField] BoxCollider2D box;
    EggType spawnEggType;
    bool criticalState;
    Bounds bounds;
    [SerializeField] float spawnCooldown;
    [SerializeField] float specialSpawnCooldown;
    int eggsSpawned;
    float randomCooldown;

    void Start()
    {
        eggsSpawned = 0;
        bounds = box.bounds;
        SpawnEgg();
    }

    public void SetCriticalState(bool state){
        criticalState = state;
    }

    public void DespawnEgg(){
        egg.gameObject.SetActive(false);
        randomCooldown = Random.Range(1, randomCooldown);
        StartCoroutine(SpawnEgg());
    }

    IEnumerator SpawnEgg()
    {
        int x = (int)Random.Range(bounds.min.x, bounds.max.x);
        int y = (int)Random.Range(bounds.min.y, bounds.max.y);
        egg.transform.position = new Vector3(x, y, 0);
        eggsSpawned++;
        if(eggsSpawned%5 == 0)
            spawnEggType = (EggType)Random.Range(2,5);
        else if(criticalState)
            spawnEggType = EggType.MASS_GAINER;
        else
            spawnEggType = (EggType)Random.Range(0,2);
        egg.SetEggType(spawnEggType);
        yield return new WaitForSeconds(randomCooldown);
        egg.gameObject.SetActive(true);
    }

    bool SpawnSpecialEgg(){
        return Random.Range(0,3) == 0;
    }
}
