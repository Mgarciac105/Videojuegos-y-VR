using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTP : MonoBehaviour
{

    public GameObject tpDestino;
    public bool tpInverso;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bola"))
        {
            Vector3 posDestino = tpDestino.transform.position;

            collision.transform.position = posDestino;

            Vector3 direccion = collision.gameObject.transform.position;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if(tpInverso == true)
            {
                rb.AddForce(-direccion * 50);

            }
            else rb.AddForce(direccion * 50);


        }

    }

}
