using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlataformas : MonoBehaviour
{
    public bool direccionVertical;

    public float final;

    public float speed;

    private bool movimientoHaciaFin;
    private Vector3 posicionFin; 
    private Vector3 posicionInicio;


    private void Start()
    {

        movimientoHaciaFin = true;

        posicionInicio = transform.position;

        if (direccionVertical)
        {
            posicionFin = new Vector3(transform.position.x, final, transform.position.z);
        }
        else posicionFin = new Vector3(final, transform.position.y, transform.position.z);

        Debug.Log($"{posicionInicio}\n{posicionFin}");

    }

    private void Update()
    {
        Vector3 posicionDestino = (movimientoHaciaFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position,posicionDestino, speed * Time.deltaTime);

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
        if (collision.gameObject.CompareTag("Bolo"))
        {
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.transform.parent = transform;

        }
    }

}
