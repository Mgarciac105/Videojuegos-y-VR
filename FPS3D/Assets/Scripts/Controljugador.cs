using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controljugador : MonoBehaviour
{

    public static Controljugador instance;

    [Header("Vidas")]
    public int vidasMax;

    [Header("Stamina")]
    public float staminaActual;
    public float staminaMax;

    [Header("Movimiento")]
    public float velocidad;
    public float fuerzaSalto;
    private bool estaCorriendo;

    [Header("Puntuacion")]
    public int puntuacionActual;

    [Header("Camara")]
    public float sensibilidad;
    public float minVistaX;
    public float maxVistaX;

    public float rotacionX;
    private Camera camara;
    private Rigidbody fisica;
    private float alturaSuelo;

    [Header("Scripts")]
    private ControlArma controlArma;
    private ControlDatosJuego controlDatosJuego;
    // Start is called before the first frame update

    private void Awake()
    {
        instance= this;
        camara = Camera.main;
        fisica = GetComponent<Rigidbody>();

    }
    void Start()
    {

        alturaSuelo = GameObject.Find("Suelo").transform.localScale.y;
        this.transform.position = new Vector3 (this.transform.position.x,alturaSuelo,this.transform.position.z);
        controlArma = this.GetComponent<ControlArma>();
        controlDatosJuego=GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controlDatosJuego.juegoPausado) return;

        MovimientoJugador();

        MovimientoCamara();

        SaltoJugador();

        Disparar();
    }

    private void MovimientoCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        transform.eulerAngles += Vector3.up * ratonX;

        rotacionX += ratonY;
        rotacionX = Mathf.Clamp(rotacionX, minVistaX, maxVistaX);
        camara.transform.localRotation = Quaternion.Euler(-rotacionX, 0, 0);


    }

    private void MovimientoJugador()
    {

        float entradaX = Input.GetAxis("Horizontal") * CorrerJugador();
        float entradaZ = Input.GetAxis("Vertical") * CorrerJugador();

        Vector3 direccion = transform.right * entradaX + transform.forward * entradaZ;

        fisica.velocity = new Vector3(direccion.x, fisica.velocity.y , direccion.z);

        //controller.Move(direccion * velocidad *Time.deltaTime);


    }

    private float CorrerJugador()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaActual > 0)
        {
            QuitarStamina();
            return velocidad * 1.6f;

        }
        else
        {
            Invoke("RecargarStamina", 3.0f);
        }

        return velocidad;
    }
    
    private void SaltoJugador()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Ray rayo = new Ray(transform.position, Vector3.down);
            if(Physics.Raycast(rayo, 1.1f))
            fisica.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

        }

    }

    private void Disparar()
    {
        if (Input.GetButton("Fire1"))
        {
            if (controlArma.PuedoDisparar())
            {
                controlArma.DispararBala();
            }
        }
    }




    private void QuitarStamina()
    {
        if(staminaActual != 0)
        {
            staminaActual -=  5 * Time.deltaTime;

        }
        ControlHUD.instance.SetStaminaHUD(staminaActual);

    }

    private void RecargarStamina()
    {
        if(staminaActual < staminaMax)
        {

                staminaActual += 10 * Time.deltaTime;

        }
        ControlHUD.instance.SetStaminaHUD(staminaActual);

    }

}
