using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDatosJuego : MonoBehaviour
{

    public bool juegoPausado;

    public int vidasActual;

    public static ControlDatosJuego instance;

    public int nBalasActual;
    public int nBalasMax;

    public int puntuacion;

    public float tiempoInicial;
    public float tiempoPartida;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;

        int numInstancias = FindObjectsOfType<ControlDatosJuego>().Length;

        if (numInstancias != 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        tiempoInicial = Time.time;

    }

    private void Start()
    {
        ControlHUD.instance.SetVidaHUD(vidasActual,Controljugador.instance.vidasMax);
        ControlHUD.instance.SetMunicionHUD(nBalasActual.ToString(), nBalasMax.ToString());

        InvokeRepeating("ModificarTiempo", 0.3f,1f);

    }

    private void OnLevelWasLoaded(int level)
    {

        if (SceneManager.GetActiveScene().name != "FinNivel" || SceneManager.GetActiveScene().name != "Creditos" || SceneManager.GetActiveScene().name != "Menu")
        {

            ControlHUD.instance.SetVidaHUD(vidasActual, Controljugador.instance.vidasMax);
            ControlHUD.instance.SetMunicionHUD(nBalasActual.ToString(), nBalasMax.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            CambiarPausa();

        }


    }

    public int getVidas()
    {
        return vidasActual;
    }

    public int getBalasActual()
    {
        return nBalasActual;
    }

    public int getBalasMax()
    {
        return nBalasMax;
    }

    public void QuitarVidasJugador(int cantidad)
    {
        vidasActual -= cantidad;
        ControlHUD.instance.SetVidaHUD(vidasActual, Controljugador.instance.vidasMax);

        if (vidasActual <= 0)
        {
            FinJuego();
        }
    }

    public void IncrementarVidas(int cantidad)
    {
        if (vidasActual + cantidad >= Controljugador.instance.vidasMax)
        {
            vidasActual = Controljugador.instance.vidasMax;
        }
        else
        {
            vidasActual += cantidad;
        }
        ControlHUD.instance.SetVidaHUD(vidasActual, Controljugador.instance.vidasMax);

    }

    public void IncrementarBalasMax(int cantidad)
    {
        nBalasMax += cantidad;
        ControlHUD.instance.SetMunicionHUD(nBalasActual.ToString(), nBalasMax.ToString());
    }
    public void QuitarBalas()
    {
        nBalasActual--; 
        ControlHUD.instance.SetMunicionHUD(nBalasActual.ToString(), nBalasMax.ToString());
    }

    public void IncrementarPuntuacion(int cantidad)
    {
        puntuacion += cantidad;
        ControlHUD.instance.SetPuntuacionHUD(puntuacion.ToString("000000"));

    }

    public void ModificarTiempo()
    {
        tiempoPartida = Time.time - tiempoInicial;
        ControlHUD.instance.SetTiempoHUD((int)tiempoPartida);

    }
    public void CambiarPausa()
    {
        juegoPausado = !juegoPausado;

        //Time.timeScale = (juegoPausado) ? 0.0f : 1.0f;

        if (juegoPausado)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0.0f;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1.0f;

        }

        ControlHUD.instance.CambiarEstadoVentanaPausa(juegoPausado);

    }

    private void FinJuego()
    {
        CambiarPausa();
        ControlHUD.instance.ventanaPausa.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Muerto";
        ControlHUD.instance.ventanaPausa.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(195, 0, 14, 255);

        Debug.Log("Muerto");
    }

}
