using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    public void OnButtonNiveles()
    {
        SceneManager.LoadScene("Levels");
    }

    public void OnButtonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnButtonAgradecimientos()
    {
        SceneManager.LoadScene("Agradecimientos");
    }

    public void OnButtonSalir()
    {
        Application.Quit(); //Sale del juego
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BotonEnlace(string enlace)
    {
        Application.OpenURL(enlace);
    }
}
