using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField]Button resume;
    [SerializeField]Button exit;
    [SerializeField]SnakeMovement snake;

    void Awake()
    {
        resume.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void RestartGame()
    {
        snake.ResumeGame();
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
