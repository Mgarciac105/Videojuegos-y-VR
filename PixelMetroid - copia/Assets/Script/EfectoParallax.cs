using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{

    public float velocidadParallax;

    private Transform camara;
    private Vector3 ultimaPosicionCamara;


    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 movimientoCamara = camara.position - ultimaPosicionCamara;
        transform.Translate(new Vector3(movimientoCamara.x * velocidadParallax , movimientoCamara.y, movimientoCamara.z));
        ultimaPosicionCamara = camara.position; 
    
    }
}
