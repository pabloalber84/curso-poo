using System;

namespace Domino
{
    class Domino
    {
        // Atributos de numeros de arriba y números de abajo del domino.
        public int Espacio1, Espacio2;
        // Sobrecarga de constructor, para poner ambos valores del domino.
        public Domino(int num_arriba, int num_abajo) {
            Espacio1 = num_arriba;
            Espacio2 = num_abajo;
        }
        // Sobrecarga al operador de suma de Dominos, retorna entero de los puntos totales.
        public static int operator +(Domino a, Domino b) {
            return (a.puntos()+b.puntos());
        }
        // Metodo que retorna la suma de los puntos.
        public int puntos() {
            return Espacio1+Espacio2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Se crean objetos de la clase Domino, 2 dominos con valores [5, 6] y [2, 1]
            Domino a = new Domino(5, 6);
            Domino b = new Domino(2, 1);
            // Se imprimen los puntos totales
            Console.WriteLine("Puntos totales: {0}", a+b);
        }
    }
}
