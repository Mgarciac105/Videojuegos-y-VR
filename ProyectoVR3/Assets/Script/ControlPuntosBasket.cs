using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuntosBasket : MonoBehaviour
{

    int puntuacion;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Balon"))
        {
            puntuacion++;

            ControlUI.instance.SetPuntuacion(puntuacion.ToString());
        }
    }
}
