using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

public class ControlEnemigo : MonoBehaviour
{
    [Header("Estadisticas")]
    public int vidasActual;
    public int vidasMax;

    [Header("Movimiento")]
    public float velocidad;
    public float distanciaDisparo;
    public float yPathOffset;
    public float distanciaPersigue;
    public bool siemprePersigue;

    private List<Vector3> listaCaminos;
    private ControlArma scriptControlArma;
    private GameObject jugador;
    private Transform arma;
    
    
    // Start is called before the first frame update
    void Start()
    {
        listaCaminos = new List<Vector3>();
        scriptControlArma = GetComponent<ControlArma>();
        jugador = GameObject.Find("Jugador");
        arma = transform.GetChild(0);

        InvokeRepeating("ActualizarCaminos",0.0f, 0.5f);


             
    }

    // Update is called once per frame
    void Update()
    {

        ApuntarJugador();

        if (siemprePersigue || distanciaPersigue > Vector3.Distance(transform.position,jugador.transform.position))
        {

            if (Vector3.Distance(transform.position, jugador.transform.position) > distanciaDisparo || !PuedeVerte())
            {
                PerseguirJugador();
            }
            else
            {
                if (scriptControlArma.PuedoDisparar() ) scriptControlArma.DispararBala();
            }
        }

    }

    private void ApuntarJugador()
    {
        transform.LookAt(new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z));
        arma.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));

        
    }

    private void ActualizarCaminos()
    {
        NavMeshPath caminoCalculado = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, jugador.transform.position,NavMesh.AllAreas,caminoCalculado);

        listaCaminos = caminoCalculado.corners.ToList();
    }

    private void PerseguirJugador()
    {

        transform.position = Vector3.MoveTowards(transform.position, listaCaminos[0] + new Vector3(0, yPathOffset, 0), velocidad * Time.deltaTime);


        if (transform.position == listaCaminos[0] + new Vector3(0, yPathOffset, 0))
        {
            listaCaminos.RemoveAt(0);
        }


    }


    private bool PuedeVerte()
    {
        if (listaCaminos.Count == 1) return true;
        else return false;
    }

    public void QuitarVidasEnemigo(int cantidad)
    {

        vidasActual -= cantidad;

        if (vidasActual <= 0)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }


}
