using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNode
{
    public int x;
    public int y;
    public int jugador;//1 jugador 0 IA

}

public class MovimientoYPuntuacion
{
    public int puntuacion;
    public MyNode punto;

    public MovimientoYPuntuacion(int score, MyNode point)
    {
        this.puntuacion = score;
        this.punto = point;
    }
}


public class Script : MonoBehaviour
{

    public GameObject xPrefab;
    public GameObject oPrefab;

    public MyNode[,] grid = new MyNode[3,3];
    public List<MovimientoYPuntuacion> raizHijosPuntuacion;
   
    // Update is called once per frame
    void Update()
    {
        #region movimientos
        //fila arriba
        if (Input.GetKeyDown("q") && esMovimientoValido (0,0))
        {
            Instantiate(xPrefab, new Vector2(0, 2), Quaternion.identity);
        }
        if (Input.GetKeyDown("w") && esMovimientoValido(0, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 2), Quaternion.identity);
        }
        if (Input.GetKeyDown("e") && esMovimientoValido(0, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 2), Quaternion.identity);
        }



        //fila medio
        if (Input.GetKeyDown("a") && esMovimientoValido(1, 0))
        {
            Instantiate(xPrefab, new Vector2(0, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown("s") && esMovimientoValido(1, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 1), Quaternion.identity);
        }
        if (Input.GetKeyDown("d") && esMovimientoValido(1, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 1), Quaternion.identity);
        }


        //fila abajo
        if (Input.GetKeyDown("z") && esMovimientoValido(2, 0))
        {
            Instantiate(xPrefab, new Vector2(0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown("x") && esMovimientoValido(2, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown("c") && esMovimientoValido(2, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 0), Quaternion.identity);
        }

        #endregion

    }

    public bool esMovimientoValido(int x, int y)
    {
        if (grid[x, y] == null)
            return true;
        return false;
    }
}
