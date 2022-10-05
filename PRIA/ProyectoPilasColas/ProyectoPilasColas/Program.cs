using System;
using System.Collections;
using System.Linq;
using System.Text;
//pilas, colas y demas
using System.Collections.Generic;

namespace ProyectoPilasColas
{
    class Program
    {
        static void Main(string[] args)
        {
            iniciarPila();//pila: primero sale el ultimo introducido
            Console.WriteLine("\n<------------------------------------------------------------->\n");
            iniciarCola();//cola: primero sale el primero introducido
            Console.WriteLine("\n<------------------------------------------------------------->\n");
            iniciarLista();//mas o menos un array
            Console.WriteLine("\n<------------------------------------------------------------->\n");
            iniciarDiccionario();//key,value

        }

        #region Diccionario


        public static void iniciarDiccionario()
        {
            var marcaCoches = new Dictionary<string, string>();

            Console.WriteLine("\nCreamos un diccionario: \n");

            //metemos datos
            marcaCoches.Add("Focus", "Ford");
            marcaCoches.Add("RX-7", "Mazda");
            marcaCoches.Add("GTR", "Nissan");
            marcaCoches.Add("R8", "Audi");
            marcaCoches.Add("X6", "BMW");
            imprimeDiccionario(marcaCoches);

            //pasandole una key que nos muestre el valor
            string v = "";

            if(marcaCoches.TryGetValue("RX-7", out v))
            {
                Console.WriteLine($"\nValor encontrado: {v}\n");
            }

            //mirar si algun valor en el campo clave

            if (!marcaCoches.ContainsKey("Camaro"))
            {
                marcaCoches.Add("Camaro", "Chevrolet");
            }
            imprimeDiccionario(marcaCoches);


            //añadir con el mismo indice
            string key = "X6";

            try
            {
                
                marcaCoches.Add(key, "Audi");
            }
            catch
            {
                Console.WriteLine($"El indice {key} ya esta asignado");
            }

            //borrar

            Console.WriteLine("\nborramos un registro");
            marcaCoches.Remove("R8");

            imprimeDiccionario(marcaCoches);


            //mostramos un valor
            Console.WriteLine($"\nMostramos un valor: {marcaCoches["GTR"]}");

            //modificamos un valor
            Console.WriteLine($"\nValor sin modificar: {marcaCoches["X6"]}");
            marcaCoches["X6"] = "audi";
            Console.WriteLine($"\nModificamos un valor: {marcaCoches["X6"]}");

        }

        private static void imprimeDiccionario(Dictionary<string,string> marcaCoches)
        {
            foreach(var e in marcaCoches)
            {
                Console.WriteLine($"key-> {e.Key}, valor-> {e.Value}");
            }
        }

        #endregion

        #region Lista
        private static void iniciarLista()
        {

            var cuatroElementos = new List<String> { "agua", "fuego", "tierra", "aire" };//creamos lista

            Console.WriteLine("\nEscribiendo en lista");

            foreach(var e in cuatroElementos)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nEliminar el segundo");


            cuatroElementos.RemoveAt(2);


            foreach (var e in cuatroElementos)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nOrdenando la lista");
            cuatroElementos.Sort();

            foreach (var e in cuatroElementos)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nAñadir a la lista");
            cuatroElementos.Add("rayo");

            foreach (var e in cuatroElementos)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\nContamos los registros de la lista");

            Console.WriteLine(cuatroElementos.Count);

        }
        #endregion

        #region Pila

        private static void iniciarPila()
        {

            Stack miPila = new Stack();//creamos pila

            Console.WriteLine("Pila: ");

            meterValores("hola", miPila);
            meterValores("buenas", miPila);
            meterValores("tardes", miPila);

            for (int i = 0; i <= 2; i++)
            {

                Console.WriteLine(sacarValores(miPila));
            }
        }

        private static void meterValores(string pal, Stack pila)
        {
            //introducimos valores
            pila.Push(pal);
        }

        private static string sacarValores(Stack pila)
        {
            return (string)pila.Pop();
        }
        #endregion

        #region cola

        private static void iniciarCola()
        {
            Queue miCola = new Queue();//creamos cola

            Console.WriteLine("Cola: ");

            meterValoresCola("hola", miCola);
            meterValoresCola("Buenas", miCola);
            meterValoresCola("Tardes", miCola);

            for (int i = 0; i <= 2; i++)
            {

                Console.WriteLine(sacarValoresCola(miCola));
            }

        }
        private static void meterValoresCola(string pal,Queue cola)
        {
            //introducimos valores
            cola.Enqueue(pal);
        }

        private static string sacarValoresCola(Queue cola)
        {
            return (string)cola.Dequeue();
        }

        #endregion


    }
}
