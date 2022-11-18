using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovimiento : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<ControlJugador>().IncrementarPuntuacion();

        }
    }
}
