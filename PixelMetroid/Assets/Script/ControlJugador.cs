using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private float alturaCentro;
    // Start is called before the first frame update
    void Start()
    {

        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        alturaCentro = GetComponent<CapsuleCollider2D>().size.y / 2 - GetComponent<CapsuleCollider2D>().offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);

        if (entradaX < 0) sprite.flipX = true;
        if (entradaX > 0) sprite.flipX = false;

        //float entradaSalto = Input.GetAxis("Jump");
        //fisica.AddForce(Vector2.up * (entradaSalto * fuerzaSalto), ForceMode2D.Impulse);

        if (TocarSuelo() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        //if( (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        //{
        //    transform.Translate(new Vector2(-0.05f, 0.0f));
        //}
    }


    private bool TocarSuelo()
    {
        
        RaycastHit2D tocando = Physics2D.Raycast(transform.position + new Vector3(0,-alturaCentro,0), Vector2.down, 0.56f);
        //Debug.DrawRay(transform.position, Vector2.down, Color.red,6f);
        return (tocando.collider != null);
          
    }

}


