using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum SnakeType{
    BLUE_SNAKE, RED_SNAKE, GREEN_SNAKE
}
public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text blueSnake;
    [SerializeField] Text redSnake;
    [SerializeField] Text greenSnake;
    bool multiplayer;

    public void UpdateScore(int score, SnakeType snakeType){
        switch(snakeType){
            case SnakeType.BLUE_SNAKE : blueSnake.text = "Score : "+score; break;
            case SnakeType.RED_SNAKE : redSnake.text = "Red Snake Score : "+score; break;
            case SnakeType.GREEN_SNAKE : greenSnake.text = "Green Snake Score : "+score; break;
        }
    }
}
