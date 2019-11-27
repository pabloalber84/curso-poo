using System;
using System.Collections.Generic;

namespace Ilustrador
{
	// Se crea una clase abstracta, la cual solo podra ser heredada pero no instanciada.
	abstract class Figura 
	{
		// Atributos normales de una figura, que las tendran todas las clases heredadas.
		protected int x;
		protected int y;
		protected string color;

		// Constructor para declarar los atributos.
		public Figura(int x, int y, string c) {
			this.x = x; this.y = y; color = c;
		}

		// Metodo para imprimir el color de la figura.
		public void printColor() {
			Console.WriteLine(color);
		}

		// Metodo abstracto que dibuje la figura, solo se declara un espacio el cual las clases heredadas van a declarar
		public abstract void dibuja();
	}
	// Clase Circulo heredada de la clase Figura
	class Circulo : Figura
	{
		// Constructor de la clase enviando los atributos de acuerdo al constructor base de la clase Figura
		public Circulo(int x, int y, string c):base(x , y, c){
		}

		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada
		public override void dibuja(){
			Console.WriteLine("Se dibuja un circulo {0}", this.color);
		}
	}
	// Clase Rect heredada de la clase Figura
	class Rect : Figura
	{
		// Constructor de la clase enviando los atributos de acuerdo al constructor base de la clase Figura
		public Rect(int x, int y, string c):base(x , y, c){
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada
		public override void dibuja(){
			Console.WriteLine("Se dibuja un rectangulo {0}", this.color);
		}
	}
	// Clase del programa a la hora de iniciarlo
	class Program
	{
		// Metodo que es llamado al iniciar el programa.
		static void Main(string[] args)
		{
			// Crear lista de figuras
			List<Figura> figuras = new List<Figura>();

			// Agregar, gracias a polimorfismo, clases que heredaron de la clase Figura.
			figuras.Add(new Circulo(12,13,"verde"));
			figuras.Add(new Rect(12,13,"azul"));
			figuras.Add(new Rect(12,13,"rojo"));
			figuras.Add(new Circulo(12,13,"rojo"));

			// Pasar por cada elemento de la lista e invocar el metodo dibuja
			foreach (var item in figuras){
				item.dibuja();
			}
		}
	}
}