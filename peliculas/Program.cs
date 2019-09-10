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
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Pelicula> peliculas = new List<Pelicula>();
			peliculas.Add(new Pelicula("La forma del agua", 2017));
			peliculas.Add(new Pelicula("Moonlight", 2016));
			peliculas.Add(new Pelicula("Spotlight", 2015));
			peliculas.Add(new Pelicula("Birdman", 2014));
			peliculas.Add(new Pelicula("12 años de esclavitud", 2013));
			foreach(Pelicula pelicula in peliculas)
				pelicula.imprime();
		}
	}
}
