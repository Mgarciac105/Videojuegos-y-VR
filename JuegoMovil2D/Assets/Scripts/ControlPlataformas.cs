using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlataformas : MonoBehaviour
{
    public bool mismoInicio;
    public bool direccionVertical;

    public float final;
    public float inicio;
    public float speed;

    private bool movimientoHaciaFin;
    private bool golpeado;

    private Vector3 posicionFin; 
    private Vector3 posicionInicio;


    private void Start()
    {

        movimientoHaciaFin = true;

        if(mismoInicio)
        {
            posicionInicio = transform.position;
        }
        else if(!mismoInicio && direccionVertical)
        {
            posicionInicio = new Vector3(transform.position.x, inicio, transform.position.z);

        }
        else posicionInicio = new Vector3(inicio, transform.position.y, transform.position.z);



        if (direccionVertical)
            {
                posicionFin = new Vector3(transform.position.x, final, transform.position.z);
            }
            else
            {
                posicionFin = new Vector3(final, transform.position.y, transform.position.z);

            }

        
    }

    private void Update()
    {
        if (!golpeado)
        {
            Movimiento();

        }

    }

    private void Movimiento()
    {
        Vector3 posicionDestino = (movimientoHaciaFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, speed * Time.deltaTime);

        if (transform.position == posicionFin)
        {
            movimientoHaciaFin = false;

        }

        if (transform.position == posicionInicio)
        {
            movimientoHaciaFin = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bola"))
        {
            golpeado = true;
            this.gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

}
