using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{

    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnBotonReintentar()
    {
        ControlDatosJuego.instance.CambiarPausa();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnBotonContinuar()
    {
        ControlDatosJuego.instance.CambiarPausa();
    }

    public void OnBotonEmpezar()
    {
        SceneManager.LoadScene("Map_v1");
    }

    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");

    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }

}

