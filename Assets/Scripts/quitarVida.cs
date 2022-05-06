using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitarVida : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && collider.gameObject.GetComponent<MovimientoJugadora>().vulnerable)
        {
            collider.gameObject.GetComponent<MovimientoJugadora>().DecrementarVida();
        }
    }
}
