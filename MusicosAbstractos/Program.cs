using System;
using System.Collections.Generic;

namespace MusicosAbstractos
{
	// Generar clase abstracta
	abstract class Musico
	{
		// Crear el atributo protegido del nombre del musico
		protected string nombre;
		// Constructor para declarar el nombre del musico
		public Musico (string n){
			nombre=n;
		}
		// Metodo para que el musico salude
		public void Saluda(){
			Console.WriteLine("> Hola soy {0}",nombre);
		}
		// Metodo abstracto que imprimir como afina su instrumento, solo se declara un espacio el cual las clases heredadas tendran que rellenar declarandolo
		public abstract void Afina();
		// Metodo abstracto que imprimir como toca su instrumento, solo se declara un espacio el cual las clases heredadas tendran que rellenar declarandolo
		public abstract void Toca();
	}
	// Clase bajista, heredado de Musico
	class Bajista: Musico
	{
		// Crear atributo para nombre del bajo
		private string bajo;

		// Constructor para declarar el nombre del bajista (estableciendolo en la base de la ..
		// .. clase padre) y estableciendo el nombre del bajo
		public Bajista (string nom,string bajo) : base(nom ){
			this.bajo=bajo;
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Afina() {
			Console.WriteLine("* {0} afina su bajo {1}",nombre,bajo);
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Toca() {
			Console.WriteLine("* {0} comienza a tocar su bajo",nombre);
		}
	}
	class Guitarrista: Musico
	{
		// Crear atributo para nombre de la guitarra
		private string guitarra;

		// Constructor para declarar el nombre del guitarrista (estableciendolo en la base de la ..
		// .. clase padre) y estableciendo el nombre de la guitarra
		public Guitarrista (string nom,string guitarra) : base(nom ){
			this.guitarra = guitarra;
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Afina() {
			Console.WriteLine("* {0} afina su guitarra {1}",nombre,guitarra);
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Toca() {
			Console.WriteLine("* {0} comienza a tocar su guitarra",nombre);
		}
	}
	class Baterista: Musico
	{
		// Crear atributo para nombre de la bateria
		private string bateria;

		// Constructor para declarar el nombre del baterista (estableciendolo en la base de la ..
		// .. clase padre) y estableciendo el nombre de la bateria
		public Baterista (string nom,string bateria) : base(nom ){
			this.bateria = bateria;
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Afina() {
			Console.WriteLine("* {0} acomoda su bateria {1}",nombre,bateria);
		}
		// Declarar el metodo y remplazar por el metodo abstracto vació puesto por la clase heredada (override)
		public override void Toca() {
			Console.WriteLine("* {0} comienza a tocar su bateria",nombre);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			// Crear una lista de objetos tipo Musico
			List<Musico> banda = new List<Musico>();
			// Se puede agregar objetos instanciados de clases heredadas de la clase abstacta "Musico"
			// Agregar a la lista un nuevo objeto tipo Bajista
			banda.Add(new Bajista("Flea","Gibson"));
			// Agregar a la lista un nuevo objeto tipo Guitarrista
			banda.Add(new Guitarrista("Jimi","Fender Stratocaster"));
			// Agregar a la lista un nuevo objeto tipo Baterista
			banda.Add(new Baterista("Jerry","Yamaha"));
			Console.WriteLine("> AHORA, LES PRESENTAMOS A 'LOS ENDEMONIADOS DE TEPITO'");
			// Pasar por cada objeto de la lista y hacer que pase por los metodos de Afina(), Saluda() y Toca(), de cada uno.
			foreach(var item in banda) {
				Console.WriteLine();
				item.Afina();
				item.Saluda();
				item.Toca();
			}
		}
	}
}