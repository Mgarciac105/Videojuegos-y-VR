using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WeaponSystem : MonoBehaviour
{
    
    public GameObject bullet;
    public GameObject player;

    private Transform posicionArma;

    private void Start()
    {
        if (this.transform.parent.GetComponent<PhotonView>().IsMine)
        {
            posicionArma = GetComponent<Transform>();
        }
    }
    private void Update()
    {
        Disparar();
    }
    private void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet,posicionArma.position,posicionArma.rotation);
        }
    }
}
