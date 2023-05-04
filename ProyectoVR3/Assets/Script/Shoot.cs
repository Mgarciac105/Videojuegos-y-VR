using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public float shootForce;

    LineRenderer line;
    RaycastHit hit;


    private void Start()
    {
        line = shootPoint.GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Instantiate(bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);

                    if (Physics.Raycast(transform.position,transform.forward,out hit))
                    {
                        line.SetPosition(0, transform.position);
                        line.SetPosition(1, hit.point);

                        if (hit.collider.tag == "Objetivo")
                        {

                           StartCoroutine(ControlObjetivo.instance.Acierto(hit.collider.gameObject.transform.parent.gameObject));

                        }
          
                    }


                }
            }
        }    
    }
}
