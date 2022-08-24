using UnityEngine;

public class Health : MonoBehaviour
{
    bool alive;
    Snake snake;
    [SerializeField] GameObject bodyPrefab;
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
            if(managerSA.specialAbilityStatus(SpecialAbility.DISABLED))
                return;
            managerSA.UpdateSAColor();
    }

    public void KillSnake(){
        alive = false;
    }

    public bool IsAlive(){
        return alive;
    }
}
