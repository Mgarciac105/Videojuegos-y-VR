using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNode
{
    public int x;
    public int y;
    public int jugador;//1 jugador 2 IA

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
            meteNodo(0, 0);
            callMinimax(0,1);
            ponO();
        }
        if (Input.GetKeyDown("w") && esMovimientoValido(0, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 2), Quaternion.identity);
            meteNodo(0, 1);
            callMinimax(0,1);
            ponO();
        }
        if (Input.GetKeyDown("e") && esMovimientoValido(0, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 2), Quaternion.identity);
            meteNodo(0, 2);
            callMinimax(0,1);
            ponO();
        } 



        //fila medio
        if (Input.GetKeyDown("a") && esMovimientoValido(1, 0))
        {
            Instantiate(xPrefab, new Vector2(0, 1), Quaternion.identity);
            meteNodo(1, 0);
            callMinimax(0,1);
            //ponO();
        }
        if (Input.GetKeyDown("s") && esMovimientoValido(1, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 1), Quaternion.identity);
            meteNodo(1, 1);
            callMinimax(0,1);
            ponO();
        }
        if (Input.GetKeyDown("d") && esMovimientoValido(1, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 1), Quaternion.identity);
            meteNodo(1, 2);
            callMinimax(0, 1);
            ponO();
        }


        //fila abajo
        if (Input.GetKeyDown("z") && esMovimientoValido(2, 0))
        {
            Instantiate(xPrefab, new Vector2(0, 0), Quaternion.identity);
            meteNodo(2, 0);
            callMinimax(0,1);
            ponO();
        }
        if (Input.GetKeyDown("x") && esMovimientoValido(2, 1))
        {
            Instantiate(xPrefab, new Vector2(1, 0), Quaternion.identity);
            meteNodo(2, 1);
            callMinimax(0,1);
            ponO();
        }
        if (Input.GetKeyDown("c") && esMovimientoValido(2, 2))
        {
            Instantiate(xPrefab, new Vector2(2, 0), Quaternion.identity);
            meteNodo(2, 2);
            callMinimax(0,1);
            ponO();
        }

        #endregion

    }

    private void ponO()
    {

        //Conseguimos el mejor movimiento
        MyNode best = returnBestMove();

        if (esMovimientoValido(best.x,best.y))
        {
            int[] valorReal = this.transforma(best.x, best.y);
            Debug.Log("Coordenadas" + best.x + ", " + best.y);
            Instantiate(oPrefab, new Vector2(valorReal[0], valorReal[1]), Quaternion.identity);
            best.jugador = 2;
            grid[best.x, best.y] = best;
        }
    }

    private int[] transforma(int x, int y)
    {
        int[] aux = new int[2];
        if (x == 0 && y == 0) { aux[0] = 0; aux[0] = 2; }
        if (x == 0 && y == 1) { aux[0] = 1; aux[1] = 2; }
        if (x == 0 && y == 2) { aux[0] = 2; aux[2] = 2; }

        if (x == 1 && y == 0) { aux[0] = 0; aux[0] = 1; }
        if (x == 1 && y == 1) { aux[0] = 1; aux[1] = 1; }
        if (x == 1 && y == 2) { aux[0] = 2; aux[2] = 1; }

        if (x == 2 && y == 0) { aux[0] = 0; aux[0] = 0; }
        if (x == 2 && y == 1) { aux[0] = 1; aux[1] = 0; }
        if (x == 2 && y == 2) { aux[0] = 2; aux[2] = 0; }

        return aux;




    }

    private MyNode returnBestMove()
    {
        int max = -10000;
        int best = -1;

        //de cada hijo lo miramos para su mejor movimiento
        for (int i = 0; i < raizHijosPuntuacion.Count; i++)
        {
            //comprobamos que la posicion no esta ocupada
            if(max<raizHijosPuntuacion[i].puntuacion && esMovimientoValido(raizHijosPuntuacion[i].punto.x, raizHijosPuntuacion[i].punto.y))
            {
                max = raizHijosPuntuacion[i].puntuacion;
                best = i;
            }
        }

        if(best > -1)
        {
            return raizHijosPuntuacion[best].punto;
        }

        MyNode blank = new MyNode();
        blank.x = 0;
        blank.y = 0;
        return blank;
    }

    private void callMinimax(int depth, int turn)
    {

        raizHijosPuntuacion = new List<MovimientoYPuntuacion>();
        miniMax(depth, turn);

    }

    public int miniMax(int depth, int turn)
    {
        if (hasXWon()) return +1;//humano win 
        if (hasOWon()) return +1;//ordenador win

        List<MyNode> pointsAvailable = getMoves();

        if (pointsAvailable.Capacity == 0) return 0;

        List<int> scores = new List<int>();
        for (int i = 0; i < pointsAvailable.Count; i++)//recorrer los sucesores
        {
            MyNode point = pointsAvailable[i];
            //segun el turno a quien le toque mover vemos la fncion
            if(turn == 1)//turno X
            {
                MyNode x = new MyNode();
                x.x = point.x;
                x.y = point.y;
                x.jugador = 2;
                grid[point.x, point.y] = x;


                int currentScore = miniMax(depth + 1, 2);
                scores.Add(currentScore);

                if(depth ==0)
                {
                    MovimientoYPuntuacion m = new MovimientoYPuntuacion(currentScore,point);
                    m.punto = point;
                    m.puntuacion = currentScore;
                    raizHijosPuntuacion.Add(m);
                }
            }
            else if(turn == 2)
            {
                MyNode o = new MyNode();
                o.x = point.x;
                o.y = point.y;
                o.jugador = 2;
                grid[point.x, point.y] = o;


                int currentScore = miniMax(depth + 1, 1);
                scores.Add(currentScore);

            }

            grid[point.x, point.y] = null;
        }

        return turn == 1 ? returnMax(scores) : returnMin(scores);

    }

    private int returnMin(List<int> scores)
    {
        int min = 10000;
        int index = -1;

        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] < min)
            {
                min = scores[i];
                index = i;
            }
        }
        return scores[index];
    }

    private int returnMax(List<int> scores)
    {

        int max = -10000;
        int index = 1;

        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] > max)
            {
                max = scores[i];
                index = i;
            }
        }
        return scores[index];
    }

    private void meteNodo(int v1, int v2)
    {

        MyNode node = new MyNode();
        node.x = v1;
        node.y = v2;
        node.jugador = 1;//humano
        grid[node.x, node.y] = node;
    }

    public bool esMovimientoValido(int x, int y)
    {
        if (grid[x, y] == null)
            return true;
        return false;
    }

    public bool esFinal()
    {
        //TextAlignment text = ui.GetComponent<text>();

        if(getMoves().Capacity == 0)
        {
          //  text.text() = "Son tablas";
            Debug.Log("Son tablas");
            return true;
        }

        if (hasOWon())
        {
            //text.text() = "O Gana";
            Debug.Log("O Gana");
            return true;
        }

        if (hasOWon())
        {
            //text.text() = "X Gana";
            Debug.Log("X Gana");
            return true;
        }
        return false;
    }

    private List<MyNode> getMoves()
    {

        List <MyNode> result= new List<MyNode>();

        for (int i = 0; i < 3; i++)
        {
            for (int h = 0; h < 3; h++)
            {
                if (grid[i,h] == null)
                {
                    MyNode newNode = new MyNode();
                    newNode.x = i;
                    newNode.y = h;
                    result.Add(newNode);
                }
            }
        }
        return result;

    }

    private bool hasOWon()
    {

        //verificar si las posiciones estan vacias
        if(grid[0,0] !=null && grid[1,1] != null && grid[2, 2] != null)
        {
            if (grid[0, 0].jugador == grid[1, 1].jugador && grid[1, 1].jugador == grid[2, 2].jugador && grid[0,0].jugador == 1)
            {
                return true;
            }
        }


        //otra diagonal
        if (grid[0, 2] != null && grid[1, 1] != null && grid[2, 0] != null)
        {
            if (grid[0, 2].jugador == grid[1, 1].jugador && grid[1, 1].jugador == grid[2, 0].jugador && grid[0, 0].jugador == 1)
            {
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {//comprobamos filas
            if(grid[i,0]!=null && grid[i,1]!=null && grid[i, 2] != null)
            {
                if (grid[i, 0].jugador == grid[i, 1].jugador && grid[i, 1].jugador == grid[i, 2].jugador && grid[i, 0].jugador == 1)
                {
                    return true;
                }   
            }
            //comprobamos columnas
            if (grid[0, i] != null && grid[0, i] != null && grid[0, i] != null)
            {
                if (grid[0, i].jugador == grid[1, i].jugador && grid[1,i].jugador == grid[2,i].jugador && grid[0,i].jugador == 1)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool hasXWon()
    {

        //verificar si las posiciones estan vacias
        if (grid[0, 0] != null && grid[1, 1] != null && grid[2, 2] != null)
        {
            if (grid[0, 0].jugador == grid[1, 1].jugador && grid[1, 1].jugador == grid[2, 2].jugador && grid[0, 0].jugador == 2)
            {
                return true;
            }
        }


        //otra diagonal
        if (grid[0, 2] != null && grid[1, 1] != null && grid[2, 0] != null)
        {
            if (grid[0, 2].jugador == grid[1, 1].jugador && grid[1, 1].jugador == grid[2, 0].jugador && grid[0, 0].jugador == 2)
            {
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {//comprobamos filas
            if (grid[i, 0] != null && grid[i, 1] != null && grid[i, 2] != null)
            {
                if (grid[i, 0].jugador == grid[i, 1].jugador && grid[i, 1].jugador == grid[i, 2].jugador && grid[i, 0].jugador == 2)
                {
                    return true;
                }
            }
            //comprobamos columnas
            if (grid[0, i] != null && grid[0, i] != null && grid[0, i] != null)
            {
                if (grid[0, i].jugador == grid[1, i].jugador && grid[1, i].jugador == grid[2, i].jugador && grid[0, i].jugador == 2)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
