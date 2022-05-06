using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caerAlAbismo : MonoBehaviour
{
    private GameManager gameManager;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Invoke("morir", 0.5f);
        }
    }

    private void morir()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.TerminarJuego(false);
    }
}
