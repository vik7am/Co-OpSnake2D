using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    [SerializeField]SnakeController snakeController;
    [SerializeField]GameOverUI gameOverUI;
    [SerializeField]GamePauseUI gamePauseUI;
    [SerializeField]ScoreUI scoreUI;

    public static GameManager Instance(){
        return instance;
    }

    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void GameOver(){
        snakeController.StopSnake();
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
