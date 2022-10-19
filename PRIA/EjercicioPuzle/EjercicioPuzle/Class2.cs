using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace EjercicioPuzle
{
    class MiPuzle
    {
        private Nodo root;

        public MiPuzle(Nodo root)
        {
            this.root = root;

        }

        public List<Nodo> busquedaAnchura()
        {
            
            List<Nodo> abiertos = new List<Nodo>();//Nodos por visitar
            List<Nodo> cerrados = new List<Nodo>();//Nodos visitados
            List<Nodo> caminoSolucion  = new List<Nodo>();//Lista de nodos camino a la solucion

            abiertos.Add(root);//nodo actual
            bool encontrados = false;
            
            while(!encontrados && abiertos.Count > 0)
            {
                Nodo actual = abiertos[0];//Cogemos el primero de la lista

                cerrados.Add(actual);//Lo metemos en cerrados

                abiertos.RemoveAt(0);//Lo sacamos

                actual.Expandir();// y lo expandimos

                for (int i = 0; i < actual.hijos.Count; i++)
                {
                    Nodo hijoActual = actual.hijos[0];

                    actual.Imprime();

                    if (actual.esMeta())
                    {
                        Console.WriteLine("\nHemos encontrado la solucion\n");

                        actual.Imprime();
                        encontrados = true;
                        break;
                    }
                    if (!Contiene(abiertos,hijoActual) && !Contiene(cerrados,hijoActual))
                    {
                        abiertos.Add(hijoActual);//lo metemos al final de la lista

                    }

                }

            }
            return caminoSolucion;
        }

        public bool Contiene(List<Nodo> lista, Nodo aux)
        {
            bool contiene = false;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].EsMismoNodo(aux.nodo))
                {
                    contiene = true;
                }

            }
            return contiene;
        }
    }

}
