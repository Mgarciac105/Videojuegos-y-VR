using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDatosJuego : MonoBehaviour
{
    public int nVidas;
    public int tiempoNivel;
    public GameObject jugador;

    private ControlJugador scriptJugador;
    private ControlHUD scriptHUD;
    private float tiempoInicio;
    private int tiempoEmpleado;
    private int puntuacion;
    private bool hasGanado;


    private void Awake()
    {
        int numInstancias = FindObjectsOfType<ControlDatosJuego>().Length;

        if(numInstancias != 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        tiempoInicio = Time.time;
        puntuacion = 0;
        scriptJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlJugador>();
        scriptHUD = GameObject.Find("HUD").GetComponent<ControlHUD>();

        scriptHUD.setVidasHUD(nVidas.ToString());
        scriptHUD.setNPowerUps(GameObject.FindGameObjectsWithTag("PowerUp").Length.ToString());
        scriptHUD.setTiempo(tiempoNivel);

        Invoke("ModificarTiempo", 1f);

    }
    public int getPuntuacion()
    {
        return puntuacion;
    }

    public int getNVidas()
    {
        return nVidas;


    }
    // Update is called once per frame
    void Update()
    {
        tiempoPartida();

    }

    private void tiempoPartida()
    {
        tiempoEmpleado = (int)(Time.time - tiempoInicio);

        if (tiempoEmpleado > tiempoNivel) FinJuego();
    }

    public void ModificarTiempo()
    {
        scriptHUD.setTiempo(tiempoNivel - tiempoEmpleado);
        Invoke("ModificarTiempo", 1f);

    }

    public void contarPowerUps()
    {
        if (GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) ganarJuego();

        scriptHUD.setNPowerUps(GameObject.FindGameObjectsWithTag("PowerUps").Length.ToString());

    }

    private void ganarJuego()
    {
        puntuacion = (nVidas * 100) + (tiempoNivel - tiempoEmpleado);
        Debug.Log("Has ganado");

        hasGanado = true;
        SceneManager.LoadScene("FinNivel");
    }

    public void FinJuego()
    {
        hasGanado = false;
        SceneManager.LoadScene("FinNivel");
    }

    //public void SiguienteNivel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
    //}
    public void DecrementarNVidas()
    {
        nVidas--;
    }
    public void QuitarVida()
    {

        if (!scriptJugador.EsInvulnerable())
        {
            nVidas--;
            scriptJugador.HacerInvulnerable();
            scriptHUD.setVidasHUD(nVidas.ToString());

        }
        if (nVidas == 0)
        {
            Debug.Log("Muerto");
            FinJuego();
        }
        Invoke("Vulnerabilizar", 1f);

    }

    private void Vulnerabilizar()
    {
        scriptJugador.HacerVulnerable();
    }
}
