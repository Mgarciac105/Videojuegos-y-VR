using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UIInformacion : MonoBehaviourPunCallbacks, IPunObservable
{

    public TextMeshProUGUI infoTxt;
    public int playerNum;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SetPlayerOrEnemy");    
    }

    IEnumerator SetPlayerOrEnemy()
    {
        yield return new WaitForSeconds(3);
        if (photonView.IsMine)
        {
            infoTxt.text = "Soy jugador";
        }
        else
        {
            infoTxt.text = "Soy el enemigo";
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }


}
