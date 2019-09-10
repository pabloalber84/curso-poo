using System;

namespace peliculas
{
	class Pelicula
	{
		public string titulo;
		public Int16 año;
		public string pais;
		public string director;
	}
	class Program
	{
		static void Main(string[] args)
		{
			Pelicula p1 = new Pelicula();
			p1.titulo = "La forma del agua";
			p1.año = 2017;
			p1.pais = "Estados Unidos";
			p1.director = "Guillermo del Toro";

			Pelicula p2 = new Pelicula();
			p2.titulo = "Birdman";
			p2.año = 2014;
			p2.pais = "Estados Unidos";
			p2.director = "Alejandro González Iñárritu";

			Console.WriteLine("Peliculas nominadas al Oscar:\n{0} - {1}\n{2} - {3}", p1.titulo, p1.año, p2.titulo, p2.año);
		}
	}
}
