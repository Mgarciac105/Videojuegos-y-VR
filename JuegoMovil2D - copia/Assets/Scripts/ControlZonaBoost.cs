using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZonaBoost : MonoBehaviour
{

    public float speedBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bola"))
        {

            Vector3 direccion = collision.gameObject.transform.position;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            rb.AddForce(new Vector3(direccion.x * speedBoost,direccion.y,direccion.z));

        }

    }

}
