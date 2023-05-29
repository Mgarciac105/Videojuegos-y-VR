using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubo : MonoBehaviour
{


    void Start()
    {

        if (Physics.Raycast(transform.position, transform.up))
        {
            Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        }


    }
}
