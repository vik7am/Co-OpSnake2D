using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    int totalScore;
    [SerializeField] Text scoreText;

    private void Start() {
        totalScore = 0;
    }
    
    public void UpdateScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score : " + totalScore.ToString();
    }
}
