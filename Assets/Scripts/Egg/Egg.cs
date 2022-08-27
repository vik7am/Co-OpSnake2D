using UnityEngine;

public enum EggType{MASS_GAINER, MASS_BURNER, SHIELD, SCORE_BOOST, SPEED_UP}
public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;
    [SerializeField] int score;
    EggType eggType;
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
            eggSpawner.DespawnEgg();
        }
        else
            despawnTimer -= Time.deltaTime;
    }

    public EggType GetEggType(){
        return eggType;
    }

    public void SetEggType(EggType eggType){
        switch(eggType){
            case EggType.MASS_GAINER : sprite.color = Color.white; break;
            case EggType.MASS_BURNER : sprite.color = Color.grey; break;
            case EggType.SHIELD : sprite.color = Color.blue; break;
            case EggType.SCORE_BOOST : sprite.color = Color.yellow; break;
            case EggType.SPEED_UP : sprite.color = Color.red; break;
        }
        this.eggType = eggType;
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
        else if(eggType == EggType.SHIELD){
            snake.ActivateSA(SpecialAbility.SHIELD);
        }
        else if(eggType == EggType.SCORE_BOOST){
            snake.ActivateSA(SpecialAbility.SCORE_BOOST);
        }
        else if(eggType == EggType.SPEED_UP){
            snake.ActivateSA(SpecialAbility.SPEED_UP);
            snake.UpdateSpeed();
        }
        eggSpawner.DespawnEgg();
    }
}
