using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuntosBasket : MonoBehaviour
{

    public int puntuacion;

    public static ControlPuntosBasket instance;

    private void Awake()
    {
        instance = this;
    }
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
