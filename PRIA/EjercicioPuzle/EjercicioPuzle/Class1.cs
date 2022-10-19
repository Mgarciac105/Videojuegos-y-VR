using System;
using System.Collections;
using System.Collections.Generic;

public class Nodo
{
    public int[,] nodo = new int[3,3];
    public List<Nodo> hijos = new List<Nodo>();
    public Nodo padre;
    public  Nodo(int[,] aux)
        {
            for (int i = 0; i<3; i++)
			    for (int j = 0; j<3; j++)
			            this.nodo[i,j]=aux[i,j];
			
			
		}
    public void Inicializa(int[,] nodo)
    {

        int indice = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                this.nodo[i, j] = indice;
            }

        }


    }

    public void Imprime()
    {
        string str = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                str += nodo[i, j];
            }
            str += "\n";
        }
        Console.WriteLine(str);
    }

    public bool esMeta()
    {
        int indice = 0;
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
            {
                if (nodo[x, y] != indice) return false;
                indice++;
            }
        return true;
    }
    //private void Copiar(int[,] aux2)
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        for (int j = 0; j < 3; j++)
    //        {
    //            this.nodo[i, j] = aux2[i, j];
    //        }
    //    }
    //}
    public Boolean EsMismoNodo(int[,] aux)
    {
        bool mismo = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (nodo[i, j] != aux[i, j]) return false;
                mismo = true;
            }
        }
        return mismo;
    }
    #region miCodigo
    //public void mueveArriba()
    //{
    //    int[,] aux2 = this.nodo;
    //    for (int i = 0; i < 3; i++)
    //    {

    //        for (int j = 0; j < 3; j++)
    //        {

    //            if (this.nodo[i, j] == 0 && i > 0)
    //            {
    //                int nAux = aux2[(i - 1), j];
    //                int nAux2 = 0;
    //                aux2[(i - 1), j] = nAux2;
    //                aux2[i, j] = nAux;

    //                Copiar(aux2);

    //                break;
    //            }

    //        }
    //    }

    //}

    //public void mueveAbajo()
    //{
    //    int[,] aux2 = this.nodo;
    //    for (int i = 0; i < 3; i++)
    //    {

    //        for (int j = 0; j < 3; j++)
    //        {

    //            if (this.nodo[i, j] == 0 && i < 2)
    //            {
    //                int nAux = aux2[(i + 1), j];
    //                int nAux2 = 0;
    //                aux2[(i + 1), j] = nAux2;
    //                aux2[i, j] = nAux;

    //                Copiar(aux2);

    //                break;

    //            }

    //        }
    //    }

    //}


    //public void mueveIzqda()
    //{
    //    int[,] aux2 = this.nodo;
    //    for (int i = 0; i < 3; i++)
    //    {

    //        for (int j = 0; j < 3; j++)
    //        {

    //            if (this.nodo[i, j] == 0 && j > 0)
    //            {
    //                int nAux = aux2[i, (j - 1)];
    //                int nAux2 = 0;
    //                aux2[i, (j - 1)] = nAux2;
    //                aux2[i, j] = nAux;

    //                Copiar(aux2);

    //                break;
    //            }

    //        }
    //    }

    //}

    //public void mueveDcha()
    //{
    //    int[,] aux2 = this.nodo;
    //    for (int i = 0; i < 3; i++)
    //    {

    //        for (int j = 0; j < 3; j++)
    //        {

    //            if (this.nodo[i, j] == 0 && j < 2)
    //            {
    //                int nAux = aux2[i, (j + 1)];
    //                int nAux2 = 0;
    //                aux2[i, (j + 1)] = nAux2;
    //                aux2[i, j] = nAux;

    //                Copiar(aux2);

    //                break;

    //            }

    //        }
    //    }

    //}

    #endregion

    #region codigoPablo

    private void Copiar(int[,] origen, int[,] destino)
    {
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                destino[x, y] = origen[x, y];


    }//Copiar
    private void MueveArriba(int[,] nodoaux, int fila, int columna)
    {
        if (fila > 0)
        {
            int[,] destino = new int[3, 3];
            Copiar(nodoaux, destino);
            int temp = nodoaux[fila - 1, columna];
            destino[fila - 1, columna] = destino[fila, columna];
            destino[fila, columna] = temp;

            Nodo hijo = new Nodo(destino);
            hijo.padre = this;
            hijos.Add(hijo);

        }
    }

    /// Método para mover hueco abajo
    /// fila y columna es donde está el hueco
    private void MueveAbajo(int[,] nodoaux, int fila, int columna)
    {
        if (fila < 2)
        {
            int[,] destino = new int[3, 3];
            Copiar(nodoaux, destino);
            int temp = nodoaux[fila + 1, columna];
            destino[fila + 1, columna] = destino[fila, columna];
            destino[fila, columna] = temp;

            Nodo hijo = new Nodo(destino);
            hijo.padre = this;
            hijos.Add(hijo);

        }
    }// MueveAbajo



    /// Método para mover hueco a la izquierda
    /// 
    private void MueveIzquierda(int[,] nodoaux, int fila, int columna)
    {
        if (columna > 0 && columna <= 2)//El límite 2 no hace falta ponerlo
        {
            int[,] destino = new int[3, 3];
            Copiar(nodoaux, destino);
            int temp = nodoaux[fila, columna - 1];
            destino[fila, columna - 1] = destino[fila, columna];
            destino[fila, columna] = temp;

            Nodo hijo = new Nodo(destino);
            hijo.padre = this;
            hijos.Add(hijo);

        }
    }//MueveIzquierda


    /// Método para mover el hueco a la derecha
    /// 
    public void MueveDerecha(int[,] nodoaux, int fila, int columna)
    {
        if (columna >= 0 && columna < 2)
        {
            int[,] destino = new int[3, 3];
            Copiar(nodoaux, destino);
            int temp = nodoaux[fila, columna + 1];
            destino[fila, columna + 1] = destino[fila, columna];
            destino[fila, columna] = temp;

            Nodo hijo = new Nodo(destino);
            hijo.padre = this;

            hijos.Add(hijo);

            

        }

    }//MueveDerecha

    public void Expandir()
    {
        int fila = 0, columna = 0;
        //Buscamos el hueco
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (nodo[i, j] == 0) { fila = i; columna = j; }

        MueveArriba(nodo, fila, columna);
        MueveAbajo(nodo, fila, columna);
        MueveDerecha(nodo, fila, columna);
        MueveIzquierda(nodo, fila, columna);

    }//Expandir

    #endregion

}
//todo
//Metodo copiar arrays
//Metodo comprobar si el nodo es el mismo que el nodo pasad0
