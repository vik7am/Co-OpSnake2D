using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]Button restart;
    [SerializeField]Button exit;
    //[SerializeField]Text message;

    void Awake()
    {
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    /*public void ShowWinner(SnakeType looser){
        switch(looser){
            case SnakeType.RED_SNAKE : message.text = "Green Snake Won"; break;
            case SnakeType.GREEN_SNAKE : message.text = "Red Snake Won"; break;
            default : print("Error!"); break;
        }
    }*/

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
