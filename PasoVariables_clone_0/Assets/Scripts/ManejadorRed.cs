using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ManejadorRed : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI informacion;
    public static ManejadorRed manejadorRed;

    // Start is called before the first frame update

    private void Awake()
    {
        if(manejadorRed == null)
        {
            manejadorRed = this;
            DontDestroyOnLoad(this);
        }
        else { Destroy(this); }
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        informacion.text = "Conectando al servidor";
        print(informacion.text);
        Debug.Log("Conectando al master");
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Sala", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
    }

}
