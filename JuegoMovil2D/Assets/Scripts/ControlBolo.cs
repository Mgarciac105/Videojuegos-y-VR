using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBolo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            this.transform.parent = null;

        }
    }
}
