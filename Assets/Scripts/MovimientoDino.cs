using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDino : MonoBehaviour
{
    public float velocidad;

    private SpriteRenderer spRd;
    private Animator animator;

    public Vector3 posicionFin;
    private Vector3 posicionInicio;

    private bool movimientoAFin;
    public bool voltearse;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        spRd = GetComponent<SpriteRenderer>();
        posicionInicio = transform.position;
        movimientoAFin = true;
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        if (!isDead)
        {
            Vector3 posicionDestino = (movimientoAFin) ? posicionFin : posicionInicio; //si moviento es true a posicion destino le asignamos posicionFin y si no posicionInicio
            transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

            if (transform.position == posicionFin)
            {
                movimientoAFin = false;
                //Verificamos si tenemos que girar
                if (voltearse) spRd.flipX = !spRd.flipX;
            }

            if (transform.position == posicionInicio)
            {
                movimientoAFin = true;
                //Verificamos si tenemos que girar
                if (voltearse) spRd.flipX = !spRd.flipX;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && collider.gameObject.GetComponent<MovimientoJugadora>().isMelee)
        {
            Invoke("DinoDesaparece", 3f);
            isDead = true;
            animator.SetBool("isDead", isDead);
        }
        else if (collider.gameObject.CompareTag("Player") && collider.gameObject.GetComponent<MovimientoJugadora>().vulnerable && !isDead)
        {
            collider.gameObject.GetComponent<MovimientoJugadora>().DecrementarVida();
        }

    }

    private void DinoDesaparece()
    {
        Destroy(gameObject);
    }

    public void DinoDisparado()
    {
        Invoke("DinoDesaparece", 3f);
        isDead = true;
        animator.SetBool("isDead", isDead);
    }
}