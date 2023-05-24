using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public int tiempoLimiteNivel;

    public static Timer instance;

    private float timer;
    private float tiempoEmpleado;


    private void Awake()
    {
        instance = this;
    }

    private void TiempoPartida()
    {
        tiempoEmpleado += 1 * Time.deltaTime;

        timer = (int)tiempoLimiteNivel - tiempoEmpleado;

        ControlUI.instance.SetTiempo(timer.ToString("00"));


        if (timer < 0)
        {

            tiempoEmpleado = 0.0f;


        }

    }
    


}
