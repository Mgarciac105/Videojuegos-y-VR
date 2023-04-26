using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    private float alturaJugador;
    // Start is called before the first frame update
    void Start()
    {
        alturaJugador = this.GetComponentInParent<CapsuleCollider>().height;
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, alturaJugador/2, this.transform.localPosition.z);
    }


}
