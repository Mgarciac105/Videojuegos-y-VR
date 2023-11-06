using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class Conexion : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    override
    public void OnConnectedToMaster()
    {
        Debug.Log("Conectado al Master");
    }

    public void ButtonCon()
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom("Room1", options, TypedLobby.Default);

    }

    override
    public void OnJoinedRoom()
    {
        Debug.Log("Nos hemos conectado a la sala: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Hay " + PhotonNetwork.CurrentRoom.PlayerCount + " jugadores");
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel(1);
            Destroy(this);
        }

    }

}
