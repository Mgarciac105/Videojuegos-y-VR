using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 destination;
    public Vector3 min, max;
    private void Start()
    {
        //destination = routeFather.GetChild(indexChildren).position;+
        destination = RandomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    void Update()
    {



        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {

            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }


    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
