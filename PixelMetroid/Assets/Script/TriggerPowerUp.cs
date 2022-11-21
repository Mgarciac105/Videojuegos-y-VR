using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPowerUp : MonoBehaviour
{
    public int puntuacion;

    private ControlJugador scriptJugador;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            scriptJugador = collision.gameObject.GetComponent<ControlJugador>();

            this.gameObject.SetActive(false);
            Destroy(gameObject);

            scriptJugador.contarPowerUps();
       }
    }
}
