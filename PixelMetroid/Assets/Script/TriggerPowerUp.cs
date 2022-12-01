using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPowerUp : MonoBehaviour
{
    public int puntuacion;

    private ControlDatosJuego scriptControlJuego;
    // Start is called before the first frame update

    public void Start()
    {
        scriptControlJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            scriptControlJuego = collision.gameObject.GetComponent<ControlDatosJuego>();

            this.gameObject.SetActive(false);
            Destroy(gameObject);

           //scriptJugador.contarPowerUps();
       }
    }
}
