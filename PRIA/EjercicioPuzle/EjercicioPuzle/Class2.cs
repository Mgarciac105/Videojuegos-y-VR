using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace EjercicioPuzle
{
    class MiPuzle
    {
        private Nodo root;
        int cuenta = 0;


        public MiPuzle(Nodo root)
        {
            this.root = root;

        }

        public List<Nodo> busquedaAnchura()
        {

            List<Nodo> abiertos = new List<Nodo>();//Nodos por visitar
            List<Nodo> cerrados = new List<Nodo>();//Nodos visitados
            List<Nodo> caminoSolucion = new List<Nodo>();//Lista de nodos camino a la solucion

            abiertos.Add(root);//nodo actual
            bool encontrados = false;

            while (!encontrados && abiertos.Count > 0)
            {
                Nodo actual = abiertos[0];//Cogemos el primero de la lista

                cerrados.Add(actual);//Lo metemos en cerrados

                abiertos.RemoveAt(0);//Lo sacamos

                actual.Expandir();// y lo expandimos

                for (int i = 0; i < actual.hijos.Count; i++)
                {
                    Nodo hijoActual = actual.hijos[i];


                    if (actual.esMeta())
                    {
                        Console.WriteLine("\nHemos encontrado la solucion\n");

                        actual.Imprime();
                        encontrados = true;
                        Trazo(caminoSolucion, actual);

                        Console.WriteLine($"Numero de pasos: {cuenta}");

                        return caminoSolucion;

                    }
                    if (!Contiene(abiertos, hijoActual) && !Contiene(cerrados, hijoActual))
                    {
                        abiertos.Add(hijoActual);//lo metemos al final de la lista

                    }

                }

            }
            return caminoSolucion;
        }

        public List<Nodo> BusquedaProfundidad()
        {

            List<Nodo> abiertos = new List<Nodo>();//Nodos por visitar
            List<Nodo> cerrados = new List<Nodo>();//Nodos visitados
            List<Nodo> caminoSolucion = new List<Nodo>();//Lista de nodos camino a la solucion

            abiertos.Add(root);//nodo actual
            bool encontrados = false;

            int limite = 50;//limite de pasos
            int profundidad = 0;//contador de cuanto bajamos

            while (abiertos.Count > 0 && !encontrados)
            {
                Nodo actual = abiertos[0];
                cerrados.Add(actual);
                abiertos.RemoveAt(0);

                if (actual.esMeta())
                {
                    Console.WriteLine("Hemos encontrado la solucion");
                    encontrados = true;
                    Trazo(caminoSolucion, actual);
                }

                if (profundidad < limite)
                {
                    actual.Expandir();
                    profundidad++;
                    Console.WriteLine($"Profundidad ---> {profundidad}");

                    for (int i = 0; i < actual.hijos.Count; i++)
                    {
                        Nodo hijoActual = actual.hijos[i];

                        if (!Contiene(abiertos, hijoActual) && !Contiene(cerrados, hijoActual))
                        {
                            abiertos.Insert(0, hijoActual);//metemos al inicio de la lista
                        }
                    }

                }
                else
                {
                    profundidad = 0;
                    actual.hijos.Clear();
                }
            }
            return caminoSolucion;

        }
        
        public List<Nodo> BuscaAsterisco()
        {
            List<Nodo> abiertos = new List<Nodo>();
            List<Nodo> cerrados = new List<Nodo>();
            List<Nodo> caminoSolucion = new List<Nodo>();

            abiertos.Add(root);
            bool encontrado = false;

            while(abiertos.Count > 0 && !encontrado)
            {
                Nodo actual = abiertos[0];
                cerrados.Add(actual);
                abiertos.RemoveAt(0);

                actual.Expandir();

                for (int i = 0; i < actual.hijos.Count; i++)
                {
                    Nodo hijoActual = actual.hijos[i];
                    if (actual.esMeta())
                    {
                        Console.WriteLine("Hemos encontrado la solucion");
                        encontrado = true;
                        Trazo(caminoSolucion, actual);
                        break;
                    }
                    if(!Contiene(abiertos,hijoActual) && !Contiene(cerrados, hijoActual))
                    {
                        abiertos.Add(hijoActual);
                    }
                }
                abiertos = abiertos.OrderBy(x => x.malColocadas).ToList();

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

        public void Trazo(List<Nodo> camino, Nodo n)
        {

            Console.WriteLine("Trazando camino");

            Nodo actual = n;
            camino.Add(actual);

            while (actual.padre != null)
            {
                actual = actual.padre;
                camino.Add(actual);
            }
            camino.Reverse();

            for (int i = 0; i < camino.Count; i++)
            {
                camino[i].Imprime();
                cuenta++;
            }
        }
    }


}
