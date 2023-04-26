using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArma : MonoBehaviour
{

    public static ControlArma instance;

    public GameObject balaPrefab;


    public float velocidadBala;
    public float frecuenciaDisparo;

    public bool municionInfinita;

    private int municionActual;
    private int municionMax;


    private Transform puntoSalida;
    private float ultimoTiempoDisparo;


    private bool esJugador = false;

    private bool estoyRecargando = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        if (this.gameObject.name == "Jugador")
        {
            esJugador = true;


            puntoSalida = transform.GetChild(0).GetChild(0).GetChild(2);

            //scriptControlHUD.SetMunicionHUD(this.municionActual.ToString(), this.municionMax.ToString());


        }
        else
        {
            municionActual = 16;

            puntoSalida = transform.GetChild(0).GetChild(2);

        }

    }

    private void Update()
    {
        PuedoDisparar();
    }

    public bool PuedoDisparar()
    {
        if (Time.time - ultimoTiempoDisparo >= frecuenciaDisparo)
        {
            if (esJugador)
            {
                if (ControlDatosJuego.instance.nBalasActual > 0 || TengoMunicionInfinita())
                {
                    return true;
                }
                else
                {
                    if (!estoyRecargando)
                    {
                        estoyRecargando = true;
                        Invoke("Recargar", 3.0f);
                    }
                }
            }
            else
            {
                if (municionActual > 0 || TengoMunicionInfinita())
                {
                    return true;
                }
                else
                {
                    if (!estoyRecargando)
                    {
                        estoyRecargando = true;
                        Invoke("Recargar", 3.0f);
                    }
                }
            }

        }
        return false;
    }

    public void DispararBala()
    {
        ultimoTiempoDisparo = Time.time;

        if (!TengoMunicionInfinita() && esJugador) ControlDatosJuego.instance.QuitarBalas();
        if (!TengoMunicionInfinita() && !esJugador) municionActual--;



        GameObject nuevaBala = Instantiate(balaPrefab, puntoSalida.position, puntoSalida.rotation);
        nuevaBala.GetComponent<Rigidbody>().velocity = puntoSalida.forward * velocidadBala;

    }

    private bool TengoMunicionInfinita()
    {
        if (municionInfinita == true)
            return true;
        return false;
    }

    private void Recargar()
    {
        if (esJugador)
        {
            if (ControlDatosJuego.instance.nBalasMax >= 10)
            {
                ControlDatosJuego.instance.nBalasActual = 10;
                ControlDatosJuego.instance.nBalasMax -= 10;
            }
            else
            {

                ControlDatosJuego.instance.nBalasActual = ControlDatosJuego.instance.nBalasMax;
                ControlDatosJuego.instance.nBalasMax = 0;
            }

            ControlHUD.instance.SetMunicionHUD(ControlDatosJuego.instance.nBalasActual.ToString(), ControlDatosJuego.instance.nBalasMax.ToString());
        }
        else
        {
            municionActual = 16;

        }

        estoyRecargando = false;

    }

    public void IncrementarMunicion(int municion)
    {
        municionMax += municion;
    }
}

