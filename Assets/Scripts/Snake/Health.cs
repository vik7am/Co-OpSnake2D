using UnityEngine;

public class Health : MonoBehaviour
{
    /*bool alive;
    Snake snake;
    [SerializeField] Body snakeBody;
    //[SerializeField] GameObject bodyPrefab;
    [SerializeField] EggSpawner eggSpawner;
    SpecialAbilityManager managerSA;
    SnakeController snakeController;

    private void Awake() {
        managerSA = GetComponent<SpecialAbilityManager>();
        snakeController = GetComponent<SnakeController>();
    }

    void Start()
    {
        alive = true;
    }

    public void setSnake(Snake snake){
        this.snake = snake;
    }

    public void CreateBody(){
        Vector3 bodyPostion = snake.body[0].position - Vector3.right;
        Body body = Instantiate(snakeBody, snake.body[snake.body.Count -1].position, Quaternion.identity);
        body.GetComponent<Body>().SetParent(snakeController);
        snake.body.Add(body.transform);
    }

    public void IncreseLength(int length){
        for (int i = 0; i < length; i++){
            Body body = Instantiate(snakeBody, snake.body[snake.body.Count -1].position, Quaternion.identity);
            body.GetComponent<Body>().SetParent(snakeController);
            snake.body.Add(body.transform);
        }
        eggSpawner.SetCriticalState(false);
        if(managerSA == null){
            print("managersa null");
            return;
        }
            
        if(managerSA.specialAbilityStatus(SpecialAbility.DISABLED))
            return;
        managerSA.UpdateSAColor();
    }

    public void DecreaseLength(int length){
        for (int i = 0; i < length; i++){
            Destroy(snake.body[snake.body.Count-1].gameObject);
            snake.body.RemoveAt(snake.body.Count-1);
        }
        if(snake.body.Count < 3){
            eggSpawner.SetCriticalState(true);
        }
    }

    public void KillSnake(){
        alive = false;
    }

    public bool IsAlive(){
        return alive;
    }*/
}
