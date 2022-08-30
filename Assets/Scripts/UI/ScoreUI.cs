using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    int totalScore;
    int totalScoreRed;
    int totalScoreGreen;
    [SerializeField] Text snakeScore;
    [SerializeField] Text redSnake;
    [SerializeField] Text greenSnake;

    void Start() {
        totalScore = 0;
        totalScoreRed = 0;
        totalScoreGreen = 0;
    }

    public void UpdateScoreUI(int score){
        totalScore += score;
        snakeScore.text = "Score : " + totalScore;
    }

    public void UpdateScoreUI(int score, SnakeType snakeType){
        switch(snakeType){
            case SnakeType.BLUE_SNAKE : 
            totalScore += score; 
            snakeScore.text = "Score : " + totalScore; break;
            case SnakeType.RED_SNAKE : 
            totalScoreRed += score; 
            redSnake.text = "Red Snake : " + totalScoreRed; break;
            case SnakeType.GREEN_SNAKE : 
            totalScoreGreen += score;
            greenSnake.text = "Green Snake : " + totalScoreGreen; break;
        }
    }

    public int GetScore(SnakeType snakeType){
        switch(snakeType){
            case SnakeType.BLUE_SNAKE : return totalScore;
            case SnakeType.RED_SNAKE : return totalScoreRed;
            case SnakeType.GREEN_SNAKE : return totalScoreGreen;
            default : return 0;
        }
    }
}
