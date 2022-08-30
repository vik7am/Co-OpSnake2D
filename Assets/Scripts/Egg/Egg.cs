using UnityEngine;

public class Egg : MonoBehaviour
{
    EggSpawner eggSpawner;
    EggType eggType;
    SpecialAbility specialAbility;
    SpriteRenderer sprite;
    float despawnTimer;
    bool pauseDespawnTimner;
    [SerializeField] int score;
    [SerializeField] float despawnDuaration;
    [SerializeField] int massGainerValue;
    [SerializeField] int massBurnerValue;

    void Awake() {
        eggSpawner = GetComponentInParent<EggSpawner>();
        sprite = GetComponent<SpriteRenderer>();
        despawnTimer = despawnDuaration;
    }

    void Update() {
        if(pauseDespawnTimner)
            return;
        UpdateDespawnTimer();
    }

    public void SetPauseDespawnTimer(bool status){
        pauseDespawnTimner = status;
    }

    void UpdateDespawnTimer(){
        if(despawnTimer<=0){
            DespawnEgg();
        }
        else
            despawnTimer -= Time.deltaTime;
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

    /*public EggType GetEggType(){
        return eggType;
    }
    public SpecialAbility GetEggSpecialAbility(){
        return specialAbility;
    }

    public int GetMassGainerValue(){
        return massGainerValue;
    }

    public int GetMassBurnerValue(){
        return massBurnerValue;
    }

    public int GetScore(){
        return score;
    }*/

    void OnTriggerEnter2D(Collider2D collision) {
        SnakeController snake = collision.GetComponentInParent<SnakeController>();
        if (snake == null)
            return;
        CheckEggType(snake);
        DespawnEgg();
    }

    void CheckEggType(SnakeController snake){
        switch(eggType){
            case EggType.MASS_GAINER :
                snake.IncreseScore(score);
                snake.IncreseLength(massGainerValue); break;
            case EggType.MASS_BURNER :
                snake.DecreaseLength(massBurnerValue); break;
            case EggType.SPECIAL :
                CheckEggSpecialAbility(snake); break;
        }
    }

    void CheckEggSpecialAbility(SnakeController snake){
        switch(specialAbility){
            case SpecialAbility.SHIELD :
                snake.ActivateSA(SpecialAbility.SHIELD); break;
            case SpecialAbility.SCORE_BOOST :
                snake.ActivateSA(SpecialAbility.SCORE_BOOST); break;
            case SpecialAbility.SPEED_UP :
                snake.ActivateSA(SpecialAbility.SPEED_UP);
                snake.UpdateSpeed(); break;
        }
    }

    void DespawnEgg(){
        eggSpawner.CreateNewEgg();
        gameObject.SetActive(false);
    }
}
