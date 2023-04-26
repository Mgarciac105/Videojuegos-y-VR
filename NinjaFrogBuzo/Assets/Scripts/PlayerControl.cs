using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private SpriteRenderer sprite;
    private Animator anim;
    private Vector3 rotacion;

    private bool vaDerecha;

    private float alturaCentro;
    private bool doubleJump = false;
    
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            rig = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            alturaCentro = GetComponent<BoxCollider2D>().size.y / 2 - GetComponent<BoxCollider2D>().offset.y;
            rotacion = transform.eulerAngles;
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {

            MoverJugador();
            SaltarJugador();
            //FlipSprite();
            ControlCamara();
        }


    }

    private void MoverJugador()
    {
        float entradaX = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(entradaX * speed, rig.velocity.y);


        if (entradaX > 0)
        {
            GetComponent<PhotonView>().RPC("Rotate", RpcTarget.All,true);

        }
        if (entradaX < 0)
            {
            GetComponent<PhotonView>().RPC("Rotate", RpcTarget.All,false);
        }



    }

    private void SaltarJugador()
    {
        if (Input.GetButtonDown("Jump")) { 

            if (tocarSuelo())
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Debug.Log(tocarSuelo());
                doubleJump = false;
            }
            
            if(!tocarSuelo() && doubleJump != true)
            {
                rig.AddForce(Vector2.up * (jumpForce * 80) / 100, ForceMode2D.Impulse);
                doubleJump =  true;
            }

            anim.SetFloat("velocityY", rig.velocity.y);

        }

    }
    private bool tocarSuelo()
    {

        RaycastHit2D tocando = Physics2D.Raycast(transform.position + new Vector3(0, -alturaCentro - 1, 0), Vector2.down, 1.1f);
       //Debug.DrawRay(transform.position, Vector2.down, Color.red,6f);
        return (tocando.collider != null);

    }


    void ControlCamara()
    {
        Camera.main.transform.position = transform.position + (Vector3.up) + transform.forward * -10;

    }




    [PunRPC]
public void Rotate(bool var) 
    {
        if (var == true)
        {
            rotacion = new Vector3(0, 180f, 0);

        }
        else
        {
            rotacion = new Vector3 (0, -180f, 0);
        }


    }
}
