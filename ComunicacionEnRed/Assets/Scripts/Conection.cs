using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Conection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("hola");
    }

    // Update is called once per frame
    void Update()
    {
    }

    override
    public void OnConnectedToMaster()
    {
        Debug.Log("Conectando con el master");

    }
   

}
