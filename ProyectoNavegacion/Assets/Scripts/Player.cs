using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{

    public Transform routeFather;
    int indexChildren;
    Vector3 destination;
    public Vector3 min,max;


    private void Start()
    {
        //destination = routeFather.GetChild(indexChildren).position;+
        destination = RandomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    void Update()
    {



        if (Vector3.Distance(transform.position, destination) < 1.5f)
        {
            //indexChildren++;
            //if(indexChildren >= routeFather.childCount)
            //{
            //    indexChildren = 0;
            //}

            //indexChildren = Random.Range(0, routeFather.childCount);

            //destination = routeFather.GetChild(indexChildren).position;
            //GetComponent<NavMeshAgent>().SetDestination(destination);

            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    RaycastHit hit = new RaycastHit();

        //    if(Physics.Raycast(ray,out hit,1000f))
        //    {
        //        GetComponent<NavMeshAgent>().SetDestination(hit.point);
        //    }
        //}
    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
