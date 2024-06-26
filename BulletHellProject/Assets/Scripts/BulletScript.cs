using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyBullet", 4.0f);
    }

    private void DestroyBullet()
    {
        this.gameObject.SetActive(false);

        Destroy(this.gameObject);
    }
}
