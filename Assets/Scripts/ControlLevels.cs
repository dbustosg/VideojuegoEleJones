using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlLevels : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Lock2;
    public GameObject Lock3;

    public GameObject Stars1_0;
    public GameObject Stars1_1;
    public GameObject Stars1_2;
    public GameObject Stars1_3;
    public GameObject Stars2_0;
    public GameObject Stars2_1;
    public GameObject Stars2_2;
    public GameObject Stars2_3;
    public GameObject Stars3_0;
    public GameObject Stars3_1;
    public GameObject Stars3_2;
    public GameObject Stars3_3;

    public Button Level2;
    public Button Level3;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        Stars1_0.SetActive(false); //de primeras se ocultan todas las imagenes que indican las estrellas conseguidas en los niveles
        Stars1_1.SetActive(false); 
        Stars1_2.SetActive(false);
        Stars1_3.SetActive(false);
        Stars2_0.SetActive(false);
        Stars2_1.SetActive(false);
        Stars2_2.SetActive(false);
        Stars2_3.SetActive(false);
        Stars3_0.SetActive(false);
        Stars3_1.SetActive(false);
        Stars3_2.SetActive(false);
        Stars3_3.SetActive(false);

        switch (gameManager.starsLevel1)
        {
            case -1: Stars1_0.SetActive(true); break; //será -1 si aún no he completado ninguna vez el nivel
            case 0: Stars1_0.SetActive(true); break;
            case 1: Stars1_1.SetActive(true); break;
            case 2: Stars1_2.SetActive(true); break;
            case 3: Stars1_3.SetActive(true); break;
        }

        if (gameManager.starsLevel1 == -1) //en este caso aún no se ha completado el nivel 1, el 2 estará bloqueado
        {
            Number2.SetActive(false);
            Level2.GetComponent<Button>().enabled = false;
        }
        else
        {
            Lock2.SetActive(false);
            switch (gameManager.starsLevel2)
            {
                case -1: Stars2_0.SetActive(true); break;
                case 0: Stars2_0.SetActive(true); break;
                case 1: Stars2_1.SetActive(true); break;
                case 2: Stars2_2.SetActive(true); break;
                case 3: Stars2_3.SetActive(true); break;
            }
        }


        if (gameManager.starsLevel2 == -1) //en este caso aún no se ha completado el nivel 2, el 3 estará bloqueado
        { 
            Number3.SetActive(false);
            Level3.GetComponent<Button>().enabled = false;
        }
        else
        {
            Lock3.SetActive(false);
            switch (gameManager.starsLevel3)
            {
                case -1: Stars3_0.SetActive(true); break;
                case 0: Stars3_0.SetActive(true); break;
                case 1: Stars3_1.SetActive(true); break;
                case 2: Stars3_2.SetActive(true); break;
                case 3: Stars3_3.SetActive(true); break;
            }
        }

    }

    public void OnButtonNivel1()
    {
        gameManager.inicializarVidas();

        SceneManager.LoadScene("Scene1");
        PlayerPrefs.SetString("SceneName", "Scene1");
    }

    public void OnButtonNivel2()
    {
        gameManager.inicializarVidas();

        SceneManager.LoadScene("Scene2");
        PlayerPrefs.SetString("SceneName", "Scene2");
    }

    public void OnButtonNivel3()
    {
        gameManager.inicializarVidas();

        SceneManager.LoadScene("Scene3");
        PlayerPrefs.SetString("SceneName", "Scene3");
    }


    public void OnButtonMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
