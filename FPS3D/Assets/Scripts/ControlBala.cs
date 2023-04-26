using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    public GameObject particulasExplosion;
    
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestruirBala", 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ControlDatosJuego.instance.QuitarVidasJugador(10);
        }

        if (other.CompareTag("Enemigo")){

            ControlDatosJuego.instance.IncrementarPuntuacion(50);
            other.GetComponent<ControlEnemigo>().QuitarVidasEnemigo(25);

        }

        GameObject particulas = Instantiate(particulasExplosion, transform.position,transform.rotation) ;

        DestruirBala();

    }

    private void DestruirBala()
    {
        this.gameObject.SetActive(false);

        Destroy(this.gameObject);
    }
}
