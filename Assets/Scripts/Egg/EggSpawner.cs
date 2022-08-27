using UnityEngine;
using System.Collections;

public enum EggType{MASS_GAINER, MASS_BURNER, SPECIAL}
public class EggSpawner : MonoBehaviour
{
    [SerializeField] Egg egg;
    [SerializeField] BoxCollider2D box;
    Bounds bounds;
    [SerializeField] float minSpawnCooldown;
    [SerializeField] float maxSpawnCooldown;
    [SerializeField] int specialEggSpawnCooldown;
    int eggsSpawned;
    float randomCooldown;
    Coroutine coroutine;
    bool gameOver;

    void Start()
    {
        eggsSpawned = 0;
        gameOver = false;
        bounds = box.bounds;
        CreateNewEgg();
    }

    public void CreateNewEgg(){
        EggType eggType;
        SpecialAbility specialAbility = SpecialAbility.DISABLED;
        if(gameOver)
            return;
        egg.transform.position =  GetRandomPosition();
        eggsSpawned++;
        if(eggsSpawned % specialEggSpawnCooldown == 0){
            eggType = EggType.SPECIAL;
            specialAbility = (SpecialAbility)Random.Range(1, 4);
        }
        else if(GameManager.Instance().CheckCriticalState()){
            eggType = EggType.MASS_GAINER;
        }
        else{
            eggType = (EggType)Random.Range(0, 2);
        }
        egg.ResetEgg(eggType, specialAbility);
        if(coroutine == null)
            coroutine = StartCoroutine(SpawnEgg());
    }

    Vector2 GetRandomPosition(){
        Vector2 position;
        position.x = (int)Random.Range(bounds.min.x, bounds.max.x);
        position.y = (int)Random.Range(bounds.min.y, bounds.max.y);
        return position;
    }

    IEnumerator SpawnEgg()
    {
        randomCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
        yield return new WaitForSeconds(randomCooldown);
        egg.gameObject.SetActive(true);
        coroutine = null;
    }

    public void StopEggSpawner(){
        if(coroutine != null)
            StopCoroutine(coroutine);
        gameOver = true;
    }
}
