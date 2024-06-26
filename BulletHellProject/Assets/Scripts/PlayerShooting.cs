using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    public float shootFrecuency;

    private float lastTimeShoot;

    void Update()
    {
        

        if (Input.GetButton("Fire1"))
        {
            if(Time.time - lastTimeShoot >= shootFrecuency)
            {
                Shoot();

            }
        }
    }

    void Shoot()
    {
        lastTimeShoot = Time.time;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
    }
}
