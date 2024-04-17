using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSceneController : MonoBehaviour
{
    WinManagerController winManager;
    [SerializeField] TextMeshProUGUI textFeedback;
    // Start is called before the first frame update
    void Start()
    {
        winManager = GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinManagerController>();

        if (winManager.GetRightPlayerWins())
            textFeedback.text = "O Jogador da direita venceu!";
        else
            textFeedback.text = "O Jogador da esquerda venceu!";
    }

    public void StartGame()
    {
        Destroy(winManager.gameObject);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
