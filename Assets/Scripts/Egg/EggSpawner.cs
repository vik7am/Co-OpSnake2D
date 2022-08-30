using UnityEngine;
using System.Collections;

public enum EggType{MASS_GAINER, MASS_BURNER, SPECIAL}
public class EggSpawner : MonoBehaviour
{
    int eggsSpawned;
    float randomCooldown;
    Bounds bounds;
    Coroutine coroutine;
    [SerializeField] Egg egg;
    [SerializeField] BoxCollider2D box;
    [SerializeField] float minSpawnCooldown;
    [SerializeField] float maxSpawnCooldown;
    [SerializeField] int specialEggSpawnCooldown;
    
    void Start()
    {
        eggsSpawned = 0;
        bounds = box.bounds;
        CreateNewEgg();
    }

    public void CreateNewEgg(){
        EggType eggType;
        SpecialAbility specialAbility = SpecialAbility.DISABLED;
        egg.transform.position =  GetRandomPosition();
        eggsSpawned++;
        // If specialEggCollodown = 5 It spawns special egg after 4 normal egg spawn. 
        if(eggsSpawned % specialEggSpawnCooldown == 0){
            eggType = EggType.SPECIAL;
            specialAbility = (SpecialAbility)Random.Range(1, 4);
        }
        // Only spawns mass gainer egg if snake size is small.
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

    // Cancels the egg spawn if cooldown is active
    public void PauseEggSpawner(){
        egg.SetPauseDespawnTimer(true);
        if(coroutine != null){
            StopCoroutine(coroutine);
            eggsSpawned--;
            coroutine = null;
        }
    }

    // Spawns a new egg if no egg is active
    public void ResumeEggSpawner(){
        egg.SetPauseDespawnTimer(false);
        if(egg.gameObject.activeSelf)
            return;
        CreateNewEgg();
    }
}
