using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlataformas : MonoBehaviour
{
    // Start is called before the first frame update
   public float velocidad;
    public Vector3 posicionFin;


    private Vector3 posicionInicio;
    private bool movimientoHaciaFin;






    // Start is called before the first frame update
    void Start()
    {

        posicionInicio = transform.position;
        movimientoHaciaFin = true;
    }

    // Update is called once per frame
    void Update()
    {

            MoverPlataforma();


    }

    private void MoverPlataforma()
    {
        Vector3 posicionDestino = (movimientoHaciaFin) ? posicionFin : posicionInicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFin)
        {
            movimientoHaciaFin = false;

        }

        if (transform.position == posicionInicio)
        {
            movimientoHaciaFin = true;

        }
    }
}