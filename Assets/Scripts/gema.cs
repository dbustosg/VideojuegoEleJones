using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gema : MonoBehaviour
{
    public int cantidad;
    public AudioClip powerUpSfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugadora>().IncrementarGemas(cantidad);

            collision.GetComponent<AudioSource>().PlayOneShot(powerUpSfx);

            Destroy(gameObject);
        }
    }
}
