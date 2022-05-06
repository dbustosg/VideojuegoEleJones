using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDestroyer : MonoBehaviour
{
    void OnBecameInvisible()
    {
        //Destruimos el objeto padre cuando salga fuera de la pantalla
        Destroy(transform.parent.gameObject);
    }
}
