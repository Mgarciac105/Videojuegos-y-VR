using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoColeccionable
{
    VidasExtra,
    BalasExtra
}

public class ControlColeccionable : MonoBehaviour
{
    public TipoColeccionable recolectable;
    public int cantidad;

    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (recolectable)
            {
                case TipoColeccionable.VidasExtra:
                    ControlDatosJuego.instance.IncrementarVidas(cantidad);
                    break;

                case TipoColeccionable.BalasExtra:
                    ControlDatosJuego.instance.IncrementarBalasMax(cantidad);
                    break;
            }

            this.gameObject.SetActive(false);

            Invoke("activarColeccionable", 10f);

        }
    }
    public void activarColeccionable()
    {
        this.gameObject.SetActive(true);
    }
}
