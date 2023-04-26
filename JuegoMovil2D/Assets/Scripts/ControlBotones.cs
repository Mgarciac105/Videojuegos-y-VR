using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlBotones : MonoBehaviour
{


    public void BotonEmpezar()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void BotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void BotonSalir()
    {
        Application.Quit();
    }

    public void BotonSiguiente()
    {

        ControlPublicidad.Instance.MostrarPublicidad();

    }

    public void BotonMenu()
    {
        ControlDatosJuego.instance.contadorEscenas = 1;
        ControlDatosJuego.instance.IniciarValores();

        SceneManager.LoadScene("Menu");

    }

    public void BotonReiniciar()
    {
        ControlDatosJuego.instance.puntuacionTotal -= ControlDatosJuego.instance.puntuacionNivel;

        ControlDatosJuego.instance.IniciarValores();

        SceneManager.LoadScene(ControlDatosJuego.instance.contadorEscenas);
    }



}
