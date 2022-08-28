using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    [SerializeField] SnakeController snakeController;
    [SerializeField] SnakeController redSnake;
    [SerializeField] SnakeController greenSnake;
    [SerializeField] EggSpawner eggSpawner;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] GamePauseUI gamePauseUI;
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] bool multiplayer;

    public static GameManager Instance()
    {
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
        if(multiplayer){
            redSnake.StopSnake();
            greenSnake.StopSnake();
        }
        else
            snakeController.StopSnake();
        eggSpawner.StopEggSpawner();
        gameOverUI.gameObject.SetActive(true);
    }

    public void UpdateScore(int score, SnakeType snakeType){
        scoreUI.UpdateScoreUI(score, snakeType);
    }

    void Update()
    {
        CheckInterupts();
    }

    void CheckInterupts(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameOverUI.gameObject.activeSelf == true)
                return;
            if(multiplayer)
            {
                redSnake.StopSnake();
                greenSnake.StopSnake();
            }
            else
                snakeController.StopSnake();
            gamePauseUI.gameObject.SetActive(true);
        }
    }

    public void ResumeGame(){
        gamePauseUI.gameObject.SetActive(false);
        if(multiplayer){
            redSnake.StartSnake();
            greenSnake.StartSnake();
        }
        snakeController.StartSnake();
    }

    public bool CheckCriticalState(){
        if(multiplayer)
            return (redSnake.CriticalState() || greenSnake.CriticalState());
        else
            return snakeController.CriticalState();
    }
}
