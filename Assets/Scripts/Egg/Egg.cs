using UnityEngine;


public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;
    [SerializeField] int score;
    EggType eggType;
    SpecialAbility specialAbility;
    SpriteRenderer sprite;
    [SerializeField]float despawnDuaration;
    float despawnTimer;

    private void Awake() {
        eggSpawner = GetComponentInParent<EggSpawner>();
        sprite = GetComponent<SpriteRenderer>();
        despawnTimer = despawnDuaration;
    }

    private void Update() {
        if(despawnTimer<=0){
            DespawnEgg();
        }
        else
            despawnTimer -= Time.deltaTime;
    }

    public EggType GetEggType(){
        return eggType;
    }

    public void ResetEgg(EggType eggType, SpecialAbility specialAbility){
        switch(eggType){
            case EggType.MASS_GAINER : sprite.color = Color.white; break;
            case EggType.MASS_BURNER : sprite.color = Color.grey; break;
        }
        switch(specialAbility){
            case SpecialAbility.SHIELD : sprite.color = Color.blue; break;
            case SpecialAbility.SCORE_BOOST : sprite.color = Color.yellow; break;
            case SpecialAbility.SPEED_UP : sprite.color = Color.red; break;
        }
        this.eggType = eggType;
        this.specialAbility = specialAbility;
        despawnTimer = despawnDuaration;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        SnakeController snake = collision.GetComponentInParent<SnakeController>();
        if (snake == null)
            return;
        if(eggType == EggType.MASS_GAINER){
            snake.IncreseScore(score);
            snake.IncreseLength(1);
        }
        else if(eggType == EggType.MASS_BURNER){
            snake.DecreaseLength(1);
        }
        else if(specialAbility == SpecialAbility.SHIELD){
            snake.ActivateSA(SpecialAbility.SHIELD);
        }
        else if(specialAbility == SpecialAbility.SCORE_BOOST){
            snake.ActivateSA(SpecialAbility.SCORE_BOOST);
        }
        else if(specialAbility == SpecialAbility.SPEED_UP){
            snake.ActivateSA(SpecialAbility.SPEED_UP);
            snake.UpdateSpeed();
        }
        DespawnEgg();
    }

    void DespawnEgg(){
        eggSpawner.CreateNewEgg();
        gameObject.SetActive(false);
    }
        
    
}
