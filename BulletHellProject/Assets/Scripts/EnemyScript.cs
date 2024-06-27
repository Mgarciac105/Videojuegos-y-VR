using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{


    public Transform player;
    public float speed;
    public float stoppingDistance; // Distancia a la que el enemigo se detendrá respecto al jugador

    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.speed = speed;
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollow();
    }


    private void EnemyFollow()
    {
        if(player != null) 
            {
            navMeshAgent.SetDestination(player.position);

        }
    }

}
