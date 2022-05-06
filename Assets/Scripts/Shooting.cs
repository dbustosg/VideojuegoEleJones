using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float Velocidad = 50.0F;

    //Variables privadas
    private Rigidbody2D thisRigidbody;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        thisRigidbody.transform.Translate(new Vector3(Velocidad, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            //Si el ataque colisiona contra un objeto con el tag 'Enemigo'
            other.gameObject.GetComponent<MovimientoDino>().DinoDisparado();

            //Destruimos el objeto cuando colisione contra un enemigo
            Destroy(gameObject);
        }
    }
}
