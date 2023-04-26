using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    public GameObject enemigo;

    void Update()
    {
        encontrarSpawn();
    }

    private void encontrarSpawn()
    {

        int rnd = Random.Range(0, 5);

        StartCoroutine(spawnEnemigos(transform.GetChild(rnd).transform.position));

    }
IEnumerator spawnEnemigos(Vector3 posicion)
    {
        while (GameObject.FindGameObjectsWithTag("Enemigo").Length < 6 )
        {
            Instantiate(enemigo ,posicion, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}