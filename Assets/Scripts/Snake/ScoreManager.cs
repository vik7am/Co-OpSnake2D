using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]ScoreUI scoreUI;
    [SerializeField] SnakeType snakeType;
    int totalScore;

    void Start()
    {
        totalScore = 0;
    }

    public void IncreseScore(int score)
    {
        totalScore += score;
        scoreUI.UpdateScore(totalScore, snakeType);
    }

    public SnakeType GetSnakeType(){
        return snakeType;
    }
}
