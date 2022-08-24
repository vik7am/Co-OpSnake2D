using UnityEngine;

public class Health : MonoBehaviour
{
    bool alive;
    Snake snake;
    [SerializeField] GameObject bodyPrefab;
    [SerializeField] EggSpawner eggSpawner;
    SpecialAbilityManager managerSA;

    private void Awake() {
        managerSA = GetComponent<SpecialAbilityManager>();
    }

    void Start()
    {
        alive = true;
    }

    public void setSnake(Snake snake){
        this.snake = snake;
    }

    public void IncreseLength(int length){
        for (int i = 0; i < length; i++)
            snake.body.Add(Instantiate(bodyPrefab, snake.body[snake.body.Count -1].position, Quaternion.identity).transform);
        eggSpawner.SetCriticalState(false);
        if(managerSA.specialAbilityStatus(SpecialAbility.DISABLED))
            return;
        managerSA.UpdateSAColor();
    }

    public void DecreaseLength(int length){
        for (int i = 0; i < length; i++){
            Destroy(snake.body[snake.body.Count-1].gameObject);
            snake.body.RemoveAt(snake.body.Count-1);
        }
        if(snake.body.Count <= 2){
            eggSpawner.SetCriticalState(true);
        }
    }

    public void KillSnake(){
        alive = false;
    }

    public bool IsAlive(){
        return alive;
    }
}
