using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{

    private void Update()
    {
        Invoke("DestruirBala", 2.0f);

    }
    void DestruirBala()
    {
        Destroy(this.gameObject);
    }
}
