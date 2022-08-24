using UnityEngine;

public enum EggType{MASS_GAINER, MASS_BURNER, SPECIAL}
public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;
    [SerializeField] int score;
    EggType eggType;
    SpriteRenderer sprite;

    private void Awake() {
        eggSpawner = GetComponentInParent<EggSpawner>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public EggType GetEggType(){
        return eggType;
    }

    public void SetEggType(EggType eggType){
        
        switch(eggType){
            case EggType.MASS_GAINER : sprite.color = Color.white; break;
            case EggType.MASS_BURNER : sprite.color = Color.gray; break;
        }
        this.eggType = eggType;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        SnakeController snake = collision.GetComponent<SnakeController>();
        if (snake == null)
            return;
        
        if(eggType == EggType.MASS_BURNER){
            snake.DecreaseLength(1);
        }
        if(eggType == EggType.MASS_GAINER){
            snake.IncreseScore(score);
            snake.IncreseLength(1);
        }
        eggSpawner.SpawnEgg();
    }
}
