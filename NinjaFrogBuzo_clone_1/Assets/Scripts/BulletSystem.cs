using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {
            ControlHUD.instance.puntuacion += 100;
            ControlHUD.instance.SetPuntuacionHUD(ControlHUD.instance.puntuacion.ToString("000000"));
        }
    }
}
