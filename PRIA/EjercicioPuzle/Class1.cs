using System;

public class Nodo
{
    public int[,] nodo = new int[3,3];

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
}

