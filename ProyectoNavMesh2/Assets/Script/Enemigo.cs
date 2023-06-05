using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemigo : MonoBehaviour
{

    public GameObject player;

    private Vector3 posicionPlayer;

    // Update is called once per frame
    void Update()
    {

        posicionPlayer = player.transform.position;
        GetComponent<NavMeshAgent>().SetDestination(posicionPlayer);

        if (Vector3.Distance(transform.position, posicionPlayer) < 2.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
