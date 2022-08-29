using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    [SerializeField] SnakeController snakeController;
    [SerializeField] SnakeController redSnake;
    [SerializeField] SnakeController greenSnake;
    [SerializeField] EggSpawner eggSpawner;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] GamePauseUI gamePauseUI;
    [SerializeField] ScoreUI scoreUI;
    [SerializeField] bool multiplayer;

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

    public void GameOver(SnakeType snakeType){
        if(multiplayer){
            redSnake.StopSnake();
            greenSnake.StopSnake();
        }
        else
            snakeController.StopSnake();
        eggSpawner.PauseEggSpawner();
        string result = GetResult(snakeType);
        gameOverUI.UpdateUI(result);
        gameOverUI.gameObject.SetActive(true);
    }

    string GetResult(SnakeType looser){
        string message = "";
        switch(looser){
            case SnakeType.BLUE_SNAKE :
                message = "Your Score : " + scoreUI.GetScore(SnakeType.BLUE_SNAKE) + " points"; break;
            case SnakeType.RED_SNAKE : 
                message = "Green Snake Won with " + scoreUI.GetScore(SnakeType.GREEN_SNAKE) + " points"; break;
            case SnakeType.GREEN_SNAKE : 
                message = "Red Snake Won with " + scoreUI.GetScore(SnakeType.RED_SNAKE) + " points"; break;
        }
        return message;
    }

    public void UpdateScore(int score, SnakeType snakeType){
        scoreUI.UpdateScoreUI(score, snakeType);
    }

    void Update(){
        CheckInterupts();
    }

    void CheckInterupts(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameOverUI.gameObject.activeSelf == true)
                return;
            eggSpawner.PauseEggSpawner();
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
        eggSpawner.ResumeEggSpawner();
        if(multiplayer){
            redSnake.StartSnake();
            greenSnake.StartSnake();
        }
        else
            snakeController.StartSnake();
    }

    public bool CheckCriticalState(){
        if(multiplayer)
            return (redSnake.CriticalState() || greenSnake.CriticalState());
        else
            return snakeController.CriticalState();
    }
}
