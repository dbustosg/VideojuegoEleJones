using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limits : MonoBehaviour
{
    //Para que el personaje no se salga por los bordes
    public Transform theTransform;
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        theTransform = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        theTransform.position = new Vector3(Mathf.Clamp(transform.position.x, Vrange.x, Vrange.y),
                                        Mathf.Clamp(transform.position.y, Hrange.x, Hrange.y),
                                        theTransform.position.z);
    }


}
