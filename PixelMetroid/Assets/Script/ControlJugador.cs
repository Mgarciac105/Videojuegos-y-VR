using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D fisica;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);

        //if( (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        //{
        //    transform.Translate(new Vector2(-0.05f, 0.0f));
        //}
    }

}
