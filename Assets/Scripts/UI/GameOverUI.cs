using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]Button restart;
    [SerializeField]Button exit;
    [SerializeField]Text result;

    void Awake()
    {
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    public void UpdateUI(string message){
        result.text = message;
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ExitGame(){
        SceneManager.LoadScene(0);
    }
}
