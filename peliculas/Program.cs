using System;

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
			Pelicula p1 = new Pelicula();
			p1.SetTitulo("La La Land");
			p1.SetAño(2016); 
			Console.WriteLine("{0}({1})", p1.GetTitulo(), p1.GetAño());
		}
	}
}
