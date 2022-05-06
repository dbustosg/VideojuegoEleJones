using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofrePistola : MonoBehaviour
{
    public AudioClip chestSfx;
    private GameManager gameManager;
    private Rigidbody2D rigidbody;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager.tengoPistola)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugadora>().CogerPistola();

            collision.GetComponent<AudioSource>().PlayOneShot(chestSfx);

            rigidbody = GameObject.Find("Torre").GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody = GameObject.Find("DecoracionTorre").GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;

            Destroy(gameObject);
        }
    }
}
