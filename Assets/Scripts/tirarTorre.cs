using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarTorre : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rigidbody = GameObject.Find("Torre").GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody = GameObject.Find("DecoracionTorre").GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;

            Destroy(gameObject);
        }
    }
}
