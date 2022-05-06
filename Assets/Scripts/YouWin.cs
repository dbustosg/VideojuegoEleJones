using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject stars0;
    public GameObject stars1;
    public GameObject stars2;
    public GameObject stars3;
    private string PrevScene;


    void Start(){
        gameManager = FindObjectOfType<GameManager>();

        stars0.SetActive(false);
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);

        int gemas = PlayerPrefs.GetInt("Gemas");
        if (gemas == 0)
            stars0.SetActive(true);
        else if (gemas == 1)
            stars1.SetActive(true);
        else if (gemas == 2)
            stars2.SetActive(true);
        else
            stars3.SetActive(true);

        PrevScene = PlayerPrefs.GetString("SceneName");
        if (PrevScene.Equals("Scene1") && gemas > gameManager.starsLevel1) 
            gameManager.starsLevel1 = gemas; //se actualizan las gemas conseguidas en ese nivel si he superado el récord
        else if (PrevScene.Equals("Scene2") && gemas > gameManager.starsLevel2)
            gameManager.starsLevel2 = gemas;
        else if (PrevScene.Equals("Scene3") && gemas > gameManager.starsLevel3)
            gameManager.starsLevel3 = gemas;
    }

    public void OnButtonNiveles()
    {
        SceneManager.LoadScene("Levels");
    }

    public void OnButtonReintentar()
    {
        gameManager.inicializarVidas();

        SceneManager.LoadScene(PrevScene);
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
