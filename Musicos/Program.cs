using System;
using System.Collections.Generic;

namespace Musicos
{
	// Generar clase
	class Musico
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
		// Metodo virtual (remplazable en sus hijos) para que el musico afine su instrumento.
		public virtual void Afina(){
			Console.WriteLine("* {0} afina su instrumento ",nombre);
		}
		// Metodo virtual (remplazable en sus hijos) para que el musico toque su instrumento.
		public virtual void Toca(){
			Console.WriteLine("* {0} comienza a tocar su instrumento ",nombre);
		}
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
		// Sobrecarga el metodo virtual definido para su redefinición, Afina.
		public override void Afina() {
			Console.WriteLine("* {0} afina su bajo {1}",nombre,bajo);
		}
		// Sobrecarga el metodo virtual definido para su redefinición, Toca.
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
		// Sobrecarga el metodo virtual definido para su redefinición, Afina.
		public override void Afina() {
			Console.WriteLine("* {0} afina su guitarra {1}",nombre,guitarra);
		}
		// Sobrecarga el metodo virtual definido para su redefinición, Toca.
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
		// Sobrecarga el metodo virtual definido para su redefinición, Afina.
		public override void Afina() {
			Console.WriteLine("* {0} acomoda su bateria {1}",nombre,bateria);
		}
		// Sobrecarga el metodo virtual definido para su redefinición, Toca.
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
			// Agregar a la lista un nuevo objeto tipo musico
			banda.Add(new Musico("Tom"));
			// Se puede agregar objetos de clases hijos (siendo el padre la clase Musico)
			// Agregar a la lista un nuevo objeto tipo Bajista
			banda.Add(new Bajista("Flea","Gibson"));
			// Agregar a la lista un nuevo objeto tipo Guitarrista
			banda.Add(new Guitarrista("Jimi","Fender Stratocaster"));
			// Agregar a la lista un nuevo objeto tipo Baterista
			banda.Add(new Baterista("Jerry","Yamaha"));
			Console.WriteLine("> AHORA, LES PRESENTAMOS A 'LOS ENDEMONIADOS DE TEPITO'");
			// Pasar por cada objeto de la lista y guardarlo en tipo var, ya que puede ser tanto musico como bajista, etc.
			foreach(var item in banda) {
				Console.WriteLine();
				item.Afina();
				item.Saluda();
				item.Toca();
			}
		}
	}
}