using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public Sprite duck;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private float alturaCentro;
    private bool dobleJump = false;
    private Animator animacion;
    private bool esInvulnerable;


    // Start is called before the first frame update
    void Start()
    {

        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        alturaCentro = GetComponent<CapsuleCollider2D>().size.y / 2 - GetComponent<CapsuleCollider2D>().offset.y;
        animacion = GetComponent<Animator>();
        esInvulnerable = false;


    }
    


    // Update is called once per frame
    void Update()
    {

        correrJugador();

        saltarJugador();

        agacharJugador();

        animarJugador();

    }

    private void agacharJugador()
    {

        if (Input.GetKey(KeyCode.S))
        {
            if (tocarSuelo())
            {
                animacion.enabled = false;
                sprite.sprite = duck;

            }
        }
        else animacion.enabled = true;

        //float entradaSalto = Input.GetAxis("Jump");
        //fisica.AddForce(Vector2.up * (entradaSalto * fuerzaSalto), ForceMode2D.Impulse);

    }
    private void correrJugador()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);



        if (entradaX < 0) sprite.flipX = true;
        if (entradaX > 0) sprite.flipX = false;


        //float entradaSalto = Input.GetAxis("Jump");
        //fisica.AddForce(Vector2.up * (entradaSalto * fuerzaSalto), ForceMode2D.Impulse);

    }

    private void saltarJugador()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            if (tocarSuelo())
            {
                fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                dobleJump = false;

            }

            if (!tocarSuelo() && dobleJump != true)
            {
                fisica.AddForce(Vector2.up * (fuerzaSalto * 60) / 100, ForceMode2D.Impulse);
                dobleJump = true;
            }

        }

        //if( (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        //{
        //    transform.Translate(new Vector2(-0.05f, 0.0f));
        //}
    }
    private bool tocarSuelo()
    {

        RaycastHit2D tocando = Physics2D.Raycast(transform.position + new Vector3(0,-alturaCentro,0), Vector2.down, 0.56f);
        //Debug.DrawRay(transform.position, Vector2.down, Color.red,6f);
        return (tocando.collider != null);

    }

    
    private void animarJugador()
    {
        if (animacion.enabled == true)
        {
            if (!tocarSuelo()) animacion.Play("JugadorSalto");
            else if ((fisica.velocity.x < -0.5) || (fisica.velocity.x > 0.5)) animacion.Play("JugadorCorriendo");
            else animacion.Play("JugadorParado");
        }
    }
 
 
    
    public  void HacerVulnerable()
    {
        esInvulnerable = false;
        sprite.color = Color.white;
    }
   
    public void HacerInvulnerable()
    {
        esInvulnerable = true;
        sprite.color = Color.red;
    }
    public bool EsInvulnerable()
    {
        return esInvulnerable;
    }
}


