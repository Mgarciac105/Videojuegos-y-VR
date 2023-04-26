using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


using Photon;
using Photon.Realtime;
using Photon.Pun;


public class ControladorPuntos : MonoBehaviourPunCallbacks
{
    public GameObject variableLocalInput;

    public TextMeshProUGUI variableLocalText;
    public TextMeshProUGUI variableRedText;

    public string tomarDatosRival = "0";

    

    public void CambiarValor()
    {
        string value = variableLocalInput.GetComponent<TMP_InputField>().text;
        variableLocalText.text = value;


        photonView.RPC(nameof(CambiarValorEnRed),RpcTarget.OthersBuffered,value);
    }

    [PunRPC]
    void CambiarValorEnRed(string variable)
    {
        variableRedText.text = variable;
    }

    private void Update()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }

}
