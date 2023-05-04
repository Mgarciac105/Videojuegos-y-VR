using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContarBolos : MonoBehaviour
{
    public GameObject particulas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bolo")){

            ControlDatosJuego.instance.IncrementarPuntuacion();
            particulas = Instantiate(particulas, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);

        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bolo"))
    //    {
    //        ControlDatosJuego.instance.DecrementarPuntuacion();

    //    }
    //}

}
