using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    //Para manipular los textos del HUD
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI powerUpsText;

    //Especificar vidas
    public void setVidasTxt(int vidas)
    {
        vidasTxt.text = "Life: " + vidas;
    }

    //Especificar powerUps
    public void setPowerUpTxt(int puntos)
    {
        powerUpsText.text = "Gems: " + puntos + " / 3";
    }
}