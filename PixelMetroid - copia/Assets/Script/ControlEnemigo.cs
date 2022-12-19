using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;
    public GameObject cangrejo;


    private Vector3 posicionInicio;
    private bool movimientoHaciaFin;
    private ControlDatosJuego controlDatosJuego;
    private SpriteRenderer sprite;
    private Animator animacion;



    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        animacion = transform.GetChild(0).GetComponent<Animator>();
        posicionInicio = transform.position;
        movimientoHaciaFin = true;
        controlDatosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
    }

    // Update is called once per frame
    void Update()
    {

        MoverEnemigo();
        
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (movimientoHaciaFin) ? posicionFin : posicionInicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFin)
        {
            movimientoHaciaFin = false;

            if(sprite.flipX == true)
            {
                sprite.flipX = false;

            }else
            sprite.flipX = true;

        }

        if (transform.position == posicionInicio)
        {

            movimientoHaciaFin = true;

            if (sprite.flipX == false)
            {
                sprite.flipX = true;

            }
            else
                sprite.flipX = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controlDatosJuego.QuitarVida();
            this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            Invoke("VolverCollider", 1f);
        }
    }

    private void VolverCollider()
    {
        this.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}
