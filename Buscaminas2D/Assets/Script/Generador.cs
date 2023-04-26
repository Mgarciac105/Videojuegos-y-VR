using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject vacio;
    public GameObject bomba;

    public int height,width,numBombas;
 

    private GameObject[][] map;
    private int x, y, rand,contadorBombas;

    public static Generador instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        Generar();

        Camera.main.transform.position = new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);
    
    }

    void Generar()
    {

        map = new GameObject[width][];


        for (x =0; x < width; x++)
        {
            map[x] = new GameObject[height];

            for(y = 0; y < height; y++)
            {
                rand = Random.Range(0, height);

                if (y == rand && contadorBombas < numBombas)
                {

                    map[x][y] = Instantiate(bomba, new Vector2(x, y), Quaternion.identity);
                    map[x][y].GetComponent<ControlClickable>().x = x;
                    map[x][y].GetComponent<ControlClickable>().y = y;
                    contadorBombas++;

                }
                else {

                    map[x][y] = Instantiate(vacio, new Vector2(x, y), Quaternion.identity);
                    map[x][y].GetComponent<ControlClickable>().x = x;
                    map[x][y].GetComponent<ControlClickable>().y = y;
                }
            }
        }

    }

    public int getCellsAround(int x, int y)
    {
        int cont = 0;

            if (x < 0 && y < height - 1 && map[x - 1][y + 1].CompareTag("Bomba")) cont++;
            if (y < height - 1 && map[x][y + 1].CompareTag("Bomba")) cont++;
            if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].CompareTag("Bomba")) cont++;
            if (x > 0 && map[x - 1][y].CompareTag("Bomba")) cont++;
            if (x < width - 1 && map[x + 1][y].CompareTag("Bomba")) cont++;
            if (x > 0 && y > 0 && map[x - 1][y - 1].CompareTag("Bomba")) cont++;
            if (y > 0 && map[x][y - 1].CompareTag("Bomba")) cont++;
            if (x < width - 1 && y > 0 && map[x + 1][y - 1].CompareTag("Bomba")) cont++;

        return cont;
    }

}
