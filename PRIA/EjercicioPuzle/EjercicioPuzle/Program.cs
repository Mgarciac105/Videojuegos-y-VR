using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace EjercicioPuzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] inicial = { { 1,2,4} ,
                               {3,0,5},
                               {7,6,8 }};

            Nodo root = new Nodo(inicial);

            root.Imprime();

            MiPuzle puzle = new MiPuzle(root);

            //List<Nodo> solucion = puzle.busquedaAnchura();
            List<Nodo> solucion = puzle.BusquedaProfundidad();


        }
    }

}
