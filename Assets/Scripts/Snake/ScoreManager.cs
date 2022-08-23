using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]ScoreUI scoreUI;
    int totalScore;

    void Start()
    {
        totalScore = 0;
    }

    public void IncreseScore(int score)
    {
        totalScore += score;
        scoreUI.UpdateScore(totalScore);
    }
}
