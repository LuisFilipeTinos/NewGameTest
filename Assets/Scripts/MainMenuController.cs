using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        //Carrega a pr�xima cena;
        SceneManager.LoadScene(1);
    }
}
