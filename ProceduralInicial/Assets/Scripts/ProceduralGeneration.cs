using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{

    [SerializeField] float width, height, minHeight, maxHeight;
    [SerializeField] int minStoneHeigh, maxStoneHeight;
    [SerializeField] int spikeHeight;
    [SerializeField] int repNum;
    [SerializeField] GameObject dirt, grass,stone,spike;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }

    private void Generation()
    {

        int repVal = 0;
        for(int x = 0; x < width; x++)
        {
            if(repVal == 0)
            {

                height = Random.Range(minHeight, maxHeight);

                GenerateFlat(x,height);
                repVal = repNum;
            }
            else
            {
                GenerateFlat(x,height);
                repVal--;
            }


            
        }

    }

    private void GenerateFlat(int x,float height)
    {
        float minStoneDistance = height - minStoneHeigh;
        float maxStoneDistance = height - maxStoneHeight;

        float totalStoneSpawnDistance = Random.Range(minStoneDistance, maxStoneDistance);

        for (int y = 0; y < height; y++)
        {

            if (y < totalStoneSpawnDistance)
            {
                spawnObject(stone, x, y);
            }
            else spawnObject(dirt, x, y);

        }
        if (height < spikeHeight)
        {
            spawnObject(spike, x, height + 0.78f);
            spawnObject(grass, x, height);

        }

        spawnObject(grass, x, height);
    }

    private void spawnObject(GameObject obj, int x, float y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
