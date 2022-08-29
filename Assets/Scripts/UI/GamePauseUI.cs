using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField]Button resume;
    [SerializeField]Button exit;
    [SerializeField]SnakeController snake;

    void Awake()
    {
        resume.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void RestartGame(){
        GameManager.Instance().ResumeGame();
    }

    void ExitGame(){
        SceneManager.LoadScene(0);
    }
}
