using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon;
using Photon.Realtime;
using Photon.Pun;

using TMPro;

public class ControlHUD : MonoBehaviourPunCallbacks
{

    private TextMeshProUGUI puntuacionText;
    private TextMeshProUGUI tiempoText;
    private TextMeshProUGUI puntuacionRed;
    public int puntuacion = 0;

    public static ControlHUD instance;
     void Awake()
    {
        instance = this;

        tiempoText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        puntuacionText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        puntuacionRed = transform.GetChild(2).GetComponent<TextMeshProUGUI>();



    }

    public void SetPuntuacionHUD(string str) {

        puntuacionText.text = str;

       photonView.RPC(nameof(SetPuntuacionRed), RpcTarget.OthersBuffered, str);
    }


    public void setTiempoHUD(int time)
    {
        int minutos = time / 60;
        int segundos = time % 60;
        tiempoText.text = minutos.ToString("00") + ":" + segundos.ToString("00");

    }

    [PunRPC]
    void SetPuntuacionRed(string str)
    {
        puntuacionRed.text= str;
    }

}
