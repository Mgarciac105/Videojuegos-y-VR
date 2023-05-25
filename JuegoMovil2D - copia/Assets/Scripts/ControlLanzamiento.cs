using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlLanzamiento : MonoBehaviour
{

    public GameObject bola;

    private Camera camara;
    private bool hasArrastrado,hasLanzado;

    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main;
        bola.GetComponent<SpringJoint2D>().distance = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        if (Touchscreen.current.primaryTouch.press.IsPressed()) EstaTocandoPantalla();
        else NoEstaTocando();

    }

    private void FixedUpdate()
    {
        ControlCamara.instance.ActualizarCamara(hasLanzado, bola);
    }

    private void EstaTocandoPantalla()
    {

        if(ControlDatosJuego.instance.nIntentos != 0)
        {
            bola.GetComponent<SpringJoint2D>().enabled = true;

            bola.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


            Vector2 posicionTocar = Touchscreen.current.primaryTouch.position.ReadValue();

            Vector3 posicionMundo = camara.ScreenToWorldPoint(posicionTocar);

            posicionMundo.z = 0;

            bola.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            //bola.GetComponent<Rigidbody2D>().isKinematic = true;

            bola.transform.position = posicionMundo;

            camara.transform.position = new Vector3(0, 0, -10);

            //camara.transform.SetParent(null);

            hasArrastrado = true;   
        }

    }

    private void NoEstaTocando()
    {
        bola.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        //bola.GetComponent<Rigidbody2D>().isKinematic = false;

        if (hasArrastrado)
        {
            hasLanzado = true;

            Invoke("Lanzar", 0.1f);
            bola.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }

        hasArrastrado = false;
    }

    private void Lanzar()
    {
        bola.GetComponent<SpringJoint2D>().enabled = false;

        ControlUI.instance.setIntentos(ControlDatosJuego.instance.nIntentos);

        ControlDatosJuego.instance.nIntentos--;

        //ControlDatosJuego.instance.CancelarFinJuego();

    }



}
