using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionArma : MonoBehaviour
{
    // Start is called before the first frame update
    private float alturaJugador;
    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.parent.parent.name == "Jugador")
        {
            alturaJugador = GameObject.Find("Jugador").GetComponent<CapsuleCollider>().height;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -(alturaJugador * 25) / 100, this.transform.localPosition.z);

        }
        else
        {
            alturaJugador = transform.GetComponentInParent<CapsuleCollider>().height;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -alturaJugador , this.transform.localPosition.z);

        }

    }
}
