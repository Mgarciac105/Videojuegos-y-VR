using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int tiempoNivel;

    private int tiempoEmpleado;
    private float tiempoInicio;
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("PinkGuy", new Vector2(-6.36000013f,-1.17999995f), Quaternion.identity);
        }
        else
        {
            switch (PhotonNetwork.LocalPlayer.ActorNumber)
            {
                case 2:
                    PhotonNetwork.Instantiate("Frog", new Vector2(37.9199982f, 3.47000003f), Quaternion.identity);
                    break;
                case 3:
                    PhotonNetwork.Instantiate("VirtualGuy", new Vector2(11.3161688f, 5.29499245f), Quaternion.identity);
                    break;

            }

        }

        tiempoInicio = Time.time;



    }

    void Update()
    {
        tiempoPartida();
        ModificarTiempo();
    }

    private void tiempoPartida()
    {
        tiempoEmpleado = (int)(Time.time - tiempoInicio);

        //if (tiempoEmpleado > tiempoNivel) FinJuego();
    }

    public void ModificarTiempo()
    {
        ControlHUD.instance.setTiempoHUD(tiempoNivel - tiempoEmpleado);
        Invoke("ModificarTiempo", 1f);

    }

}
