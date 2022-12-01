using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlBotones : MonoBehaviour
{
    public void OnBotonJugar()
    {
        //SceneManager.LoadScene(SceneManager.GetAllScenes()[1].buildIndex);

        SceneManager.LoadScene("Nivel 1");

    }
    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");

    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }
    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu1");

    }
}
