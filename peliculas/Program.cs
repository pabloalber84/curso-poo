using System;
using System.Collections.Generic;

namespace peliculas
{
	class Pelicula
	{
		private string titulo;
		private Int16 año;
		private string pais;
		private string director;
		private List<Actor> actores = new List<Actor>();
		public Pelicula() {

		}
		public Pelicula(string titulo, Int16 año) {
			this.titulo = titulo;
			this.año = año;
		}
		public void SetTitulo(string titulo) {
			this.titulo = titulo;
		}
		public string GetTitulo() {
			return this.titulo;
		}
		public void SetAño(Int16 año) {
			this.año = año;
		}
		public Int16 GetAño() {
			return this.año;
		}
		public void imprime() {
			Console.WriteLine("{0} ({1})", this.titulo, this.año);
		}
		public void AgregarActor(Actor actor) {
			actores.Add(actor);
		}
		public void ImprimeActores() {
			Console.WriteLine("Reparto:");
			foreach(Actor actor in actores)
				Console.WriteLine("{0} ({1})", actor.nombre, actor.año);
		}
	}
	class Actor
	{
		public string nombre;
		public Int16 año;
		public Actor(string nombre, Int16 año) {
			this.nombre = nombre;
			this.año = año;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Pelicula p1 = new Pelicula("La La Land", 2016);
			p1.AgregarActor(new Actor("Ryan Gosling", 1980));
			p1.AgregarActor(new Actor("Emma Stone", 1988));

			p1.ImprimeActores();
		}
	}
}
