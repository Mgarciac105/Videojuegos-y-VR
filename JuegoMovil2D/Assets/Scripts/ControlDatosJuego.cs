using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDatosJuego : MonoBehaviour
{
    [Header("Tiempo")]
    public int tiempoLimiteNivel;
    public int tiempoLimiteLanzamiento;

    private float Timer;
    private float tiempoEmpleado;

    [Header("Puntuacion")]
    public int puntuacionNivel;
    public int puntuacionTotal;

    [Header("Intentos")]
    public int nIntentos;

    [Header("instance")]
    public static ControlDatosJuego instance;


    [Header("escenas")]
    public int contadorEscenas;

    private void Awake()
    {
        instance = this;

        int numInstancias = GameObject.FindGameObjectsWithTag("DatosJuego").Length;

        if(numInstancias != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        contadorEscenas = 1;

        ControlScene();


        tiempoEmpleado = Time.time;


    }


    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "FinNivel" && SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Creditos")
        {
            TiempoPartida();
        }



    }

    public void IniciarValores()
    {

        puntuacionNivel = 0;
        nIntentos = 3;


    }
    public int GetPuntuacionNivel()
    {
        return puntuacionNivel;
    }

    public int GetPuntuacionTotal()
    {
        return puntuacionTotal;
    }

    public void IncrementarPuntuacion()
    {
        puntuacionNivel++;
    }

    public void DecrementarPuntuacion()
    {
        puntuacionNivel--;
    }

    public void IncrementarPuntuacionTotal()
    {
        puntuacionTotal += puntuacionNivel;

    }
    private void TiempoPartida()
    {
        tiempoEmpleado += 1 * Time.deltaTime;

        Timer = (int)tiempoLimiteNivel - tiempoEmpleado;

        ControlUI.instance.setTiempo(Timer.ToString("00"));


        if (Timer < 0)
        {

            tiempoEmpleado = 0.0f;
            Timer = tiempoLimiteLanzamiento;

            IncrementarPuntuacionTotal();

            FinJuego();

        }

    }


    private void PausarPartida()
    {
        Time.timeScale = 0f;

    }

    public void CancelarFinJuego()
    {
        CancelInvoke("FinJuego");
    }

    public void FinJuego()
    {
        SceneManager.LoadSceneAsync("FinNivel");

    }

    public void ControlScene()
    {
        if (SceneManager.GetActiveScene().name.Contains("Nivel")) 
        {
            contadorEscenas = SceneManager.GetActiveScene().buildIndex;
        
        }

    }
}
