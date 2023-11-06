using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneracionMapa : MonoBehaviour
{

    public int width, height, depth;

    public GameObject tierra, agua, montaña,tierraCesped,arbol;

    public int seed;
    public float detail;
    public int nArboles;

    private int[,] perlinNoiseArray;

    private int min, max, rand,contadorArboles = 0;

    void Start()
    {
        perlinNoiseArray = new int[width,depth];

        GenerarPerlinNoise();
        GenerarArboles();   
        GenerarMapa();
        Invoke("ColocarArboles",0.5f);   
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


                    if (perlinNoiseArray[x, z] < min + 1)
                    {
                        Instantiate(agua, new Vector3(x, y, z), Quaternion.identity);

                    }
                    else if (perlinNoiseArray[x, z] > max - 5)
                    {
                        Instantiate(montaña, new Vector3(x, y, z), Quaternion.identity);

                    }
                    else
                    {
                        rand = Random.Range(0, 10);

                        if (rand <= 6 && rand >= 3 && perlinNoiseArray[x, z] > min + 2 && perlinNoiseArray[x, z] < max - 5)
                        {

                            Instantiate(tierraCesped, new Vector3(x, y, z), Quaternion.identity);

                        }
                        else Instantiate(tierra, new Vector3(x, y, z), Quaternion.identity);
                    }



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
     void GenerarArboles()
    {


        for(int i = 0; i < nArboles; i++)
        {
                Instantiate(arbol, new Vector3(0,0,0), Quaternion.identity);
        }

    }

    void ColocarArboles()
    {
        GameObject[] arboles = GameObject.FindGameObjectsWithTag("Arbol");
        GameObject[] tierras = GameObject.FindGameObjectsWithTag("Tierra");


        for(int i = 0; i < tierras.Length; i++)
        {

            int rand = Random.Range(0,100);

            if(rand >=45 && rand <= 50 && tierras[i].transform.position.y > min + 2 && tierras[i].transform.position.y < max - 6 && contadorArboles < arboles.Length)
            {
                arboles[contadorArboles].transform.SetParent(tierras[i].transform);
                arboles[contadorArboles].transform.position=new Vector3(tierras[i].transform.position.x, tierras[i].transform.position.y + 0.5f, tierras[i].transform.position.z);
                contadorArboles++;
            }
        }
    }
}
