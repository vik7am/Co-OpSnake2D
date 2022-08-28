using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
    [SerializeField]Button startSingle;
    [SerializeField]Button startCoOp;
    [SerializeField]Button exitGame;

    void Awake()
    {
        startSingle.onClick.AddListener(StartSingle);
        startCoOp.onClick.AddListener(StartCoOp);
        exitGame.onClick.AddListener(ExitGame);
    }

    void StartSingle(){
        SceneManager.LoadScene(1);
    }

    void StartCoOp(){
        SceneManager.LoadScene(2);
    }

    void ExitGame(){
        Application.Quit();
    }
}
