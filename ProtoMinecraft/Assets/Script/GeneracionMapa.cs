using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionMapa : MonoBehaviour
{

    public int width, height, depth;

    public GameObject tierra, agua, monta�a;

    public int seed;
    public float detail;

    private int[,] perlinNoiseArray;

    private int min, max;

    void Start()
    {
        perlinNoiseArray = new int[width,depth];

        GenerarPerlinNoise();
        GenerarMapa();
    }

    // Update is called once per frame

    void GenerarMapa()
    {

        for(int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
    
                for (int y = 0; y < perlinNoiseArray[x,z]; y++)
                {
                    
                    if(perlinNoiseArray[x,z] < min + 1)
                    {
                        Instantiate(agua, new Vector3(x, y, z), Quaternion.identity);

                    }
                    else if(perlinNoiseArray[x,z] > max - 5)
                    {
                        Instantiate(monta�a, new Vector3(x, y, z), Quaternion.identity);

                    }
                    else Instantiate(tierra, new Vector3(x, y, z), Quaternion.identity);




                }
            }

        }
    }

    void GenerarPerlinNoise()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);

                //debug.log($"{height},{x},{z}");

                perlinNoiseArray[x,z] = height;

                if (min == 0 || min > height) min = height;
                if (max < height) max = height;
            }
        }
    }
        
}
