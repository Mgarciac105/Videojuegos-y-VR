using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public static ControlCamara instance;

    private Camera camara;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        camara = Camera.main; 
    }

    // Update is called once per frame
    public IEnumerator CamaraBola(GameObject b)
    {
        yield return new WaitForSeconds(0.01f);
        camara.transform.position = b.transform.position + (Vector3.up) + transform.forward * -10;

        CamaraBola(b);

    }
}
