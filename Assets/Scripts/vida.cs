using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public int cantidad;
    public AudioClip lifeSfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugadora>().IncrementarVida(cantidad);

            collision.GetComponent<AudioSource>().PlayOneShot(lifeSfx);

            Destroy(gameObject);
        }
    }
}
