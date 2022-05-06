using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal { get; set; }
    public int starsLevel1 { get; set; }
    public int starsLevel2 { get; set; }
    public int starsLevel3 { get; set; }
    public bool tengoCuchillo { get; set; }
    public bool tengoPistola { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene("Presentation");
        tengoCuchillo = false;
        tengoPistola = false;

        starsLevel1 = -1;
        starsLevel2 = -1;
        starsLevel3 = -1;
    }

    public void cambiarEscena(string siguienteScene)
    {
        SceneManager.LoadScene(siguienteScene);
    }

    public void inicializarVidas()
    {
        vidasGlobal = 3;
    }

    public int getVidas()
    {
        return vidasGlobal;
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
    }
    public void aumentarVidas(int cantidad)
    {
        vidasGlobal += cantidad;
    }

    public void TerminarJuego(bool ganar)
    {
        if (ganar)
            cambiarEscena("YouWin");
        else
            cambiarEscena("YouLose");
    }
}