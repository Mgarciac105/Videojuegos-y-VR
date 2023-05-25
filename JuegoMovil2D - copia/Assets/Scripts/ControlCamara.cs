using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public bool esLejano;
    public bool inicioNivel;

    public static ControlCamara instance;
    
    private Camera camara;

    private void Awake()
    {
        instance = this;
        camara = Camera.main;
    }


    private void FixedUpdate()
    {
        if (esLejano) CamaraInicio();
        else inicioNivel = true;

    }
    public void ActualizarCamara(bool aux, GameObject b) 
    {

        if (aux)
        {
            Vector3 miPosicion = new Vector3(b.transform.position.x, b.transform.position.y, camara.transform.position.z);
            camara.transform.position = miPosicion;
        }

    }

    private void CamaraInicio()
    {

        camara.transform.position = Vector3.MoveTowards(camara.transform.position, new Vector3(0,0,camara.transform.position.z), 7 * Time.deltaTime);

        if(camara.transform.position == new Vector3(0, 0, camara.transform.position.z)) inicioNivel = true;



    }

}
