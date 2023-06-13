using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpForce;

    private Rigidbody rb;
    private Animator animController;
    private bool isRotated;

    bool isJumping;
    Vector3 move;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animController =this.GetComponent<Animator>();
        isRotated = false;

    }

    private void Update()
    {

        MoverPersonaje();
        RotarPersonaje();
        SaltoPersonaje();
        
    }


    void MoverPersonaje()
    {
        float vertAxis = Input.GetAxis("Vertical");
        move = transform.forward * vertAxis * Time.deltaTime * speed;

        if (vertAxis >= 0) isRotated = false;

        if (isRotated || isJumping) return;

        if (vertAxis >= 0)
        {
            rb.velocity = move;
        }
        else
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            isRotated = !isRotated;
        }
        animController.SetBool("isWalking", move != Vector3.zero);

    }

    void RotarPersonaje()
    {
        float horAxis = Input.GetAxis("Horizontal");
        var rotate = new Vector3(0f, horAxis, 0f);
        transform.Rotate(rotate);
    }

    void SaltoPersonaje()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping )
        {   
            rb.useGravity = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            animController.SetBool("isJumping", true);


        }
    }

    
}
