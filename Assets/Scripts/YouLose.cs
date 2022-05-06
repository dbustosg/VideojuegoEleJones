using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLose : MonoBehaviour
{
    private GameManager gameManager;

    public void OnButtonNiveles()
    {
        SceneManager.LoadScene("Levels");
    }

    public void OnButtonReintentar()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.inicializarVidas();

        string PrevScene = PlayerPrefs.GetString("SceneName");
        SceneManager.LoadScene(PrevScene);
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
