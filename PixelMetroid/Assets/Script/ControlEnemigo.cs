using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;


    private Vector3 posicionInicio;
    private bool movimientoHaciaFin;

    private SpriteRenderer sprite;




    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();


        posicionInicio = transform.position;
        movimientoHaciaFin = true;
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
            sprite.flipX = true;

        }

        if (transform.position == posicionInicio)
        {
            sprite.flipX = false;
            movimientoHaciaFin = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ControlJugador>().FinJuego();
        }
    }
}