using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlExplosion : MonoBehaviour
{

    public float radio;
    public float fuerzaExplosion;

    public void Explosion()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Rigidbody2D rb = colisionador.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb.AddForce(direccion * fuerzaFinal);

                //Debug.Log($"{direccion},{distancia},{fuerzaFinal}");
            }
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Explosion", 1.5f);
        }
    }

    private void OnDrawGizmos()
     {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
