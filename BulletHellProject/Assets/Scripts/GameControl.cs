using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [Header("EnemySpawn")]
    public GameObject[] enemyPrefab;
    public GameObject player;
    public int nEnemies;
    public Transform[] spawnPoints;
    public float spawnInterval = 1f;
    
   void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

   IEnumerator SpawnEnemies()
    {
        
        for (int i = 0;i < nEnemies; i++)
        {
            Vector3 spawnPosition = RandomSpawnPoint();
            GameObject enemy = Instantiate(enemyPrefab[0], spawnPosition, Quaternion.identity);

            EnemyScript enemyFollow = enemy.GetComponent<EnemyScript>();
            if (enemyFollow != null)
            {
                enemyFollow.player = player.transform;
            }
        yield return new WaitForSeconds(spawnInterval);

        }

    }
   Vector3 RandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length );
        return spawnPoints[randomIndex].position;
    }
}
