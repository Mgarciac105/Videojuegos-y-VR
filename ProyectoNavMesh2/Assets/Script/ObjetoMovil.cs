using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ObjetoMovil : MonoBehaviour
{
    Animator anim;
    bool isOpened=false;
    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpened)
            {
                transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
                isOpened = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
                isOpened = true;
            } 

        }
    }
}
