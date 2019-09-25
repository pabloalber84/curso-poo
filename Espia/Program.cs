using System;

namespace Espia
{

    class Persona
    {
        public string nombre;
        public string apellido;

        public Persona()
        {
            nombre = "Pablo";
            apellido = "Espinoza";
        }

    }

    class Anonymous
    {
        public static void anonimiza(Persona p)
        {
            p.nombre = "xxxxx";
            p.apellido = "xxxxxxxxxx";
        }

        public static void cambia(ref  Persona p)
        {
            p = new Persona();
            p.nombre = "new";
        }
    }




    class Program
    {
        static void duplica(ref int x)
        {
            x = x * 2;
        }
        static int suma(int x, int y)
        {
            return x+y;
        }
        static void suma(int x, int y, out int resultado)
        {
            resultado = x + y;
        }
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;
            int r;
            suma(x, y, out r);
            Console.WriteLine(r);
            /*Persona p = new Persona();
            Console.WriteLine(p.nombre);
            Anonymous.anonimiza(p);
            Anonymous.cambia(ref p);
            Console.WriteLine(p.nombre);*/
        }
    }
}