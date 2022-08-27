using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    [SerializeField]SnakeController snakeController;
    [SerializeField]EggSpawner eggSpawner;
    [SerializeField]GameOverUI gameOverUI;
    [SerializeField]GamePauseUI gamePauseUI;
    [SerializeField]ScoreUI scoreUI;

    public static GameManager Instance(){
        return instance;
    }

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver(){
        snakeController.StopSnake();
        eggSpawner.StopEggSpawner();
        gameOverUI.gameObject.SetActive(true);
    }

    public void UpdateScore(int score){
        scoreUI.AddScore(score);
    }

    void Update()
    {
        CheckInterupts();
    }

    void CheckInterupts(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameOverUI.gameObject.activeSelf == true)
                return;
            snakeController.StopSnake();
            gamePauseUI.gameObject.SetActive(true);
        }
    }

    public void ResumeGame(){
        gamePauseUI.gameObject.SetActive(false);
        snakeController.StartSnake();
    }

    public bool CheckCriticalState(){
        return snakeController.CriticalState();
    }
}
