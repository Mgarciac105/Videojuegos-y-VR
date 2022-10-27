using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private float alturaCentro;
    private bool dobleJump = false;

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


        CorrerJugador();

        SaltarJugador();


    }

    private void CorrerJugador()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);

        if (entradaX < 0) sprite.flipX = true;
        if (entradaX > 0) sprite.flipX = false;

        //float entradaSalto = Input.GetAxis("Jump");
        //fisica.AddForce(Vector2.up * (entradaSalto * fuerzaSalto), ForceMode2D.Impulse);

    }

    private void SaltarJugador()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            if (TocarSuelo())
            {
                fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                dobleJump = false;

            }

            if (!TocarSuelo() && dobleJump != true)
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
    private bool TocarSuelo()
    {

        RaycastHit2D tocando = Physics2D.Raycast(transform.position + new Vector3(0,-alturaCentro,0), Vector2.down, 0.56f);
        //Debug.DrawRay(transform.position, Vector2.down, Color.red,6f);
        return (tocando.collider != null);

    }
    
    
    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).buildIndex);
    }
}


