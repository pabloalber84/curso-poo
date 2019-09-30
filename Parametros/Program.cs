using System;

namespace Parametros
{
	class Pelicula
	{
		public string titulo;
		public Int16 año;
		public string pais;
		public string director;
		public int duracion_h;
		public int duracion_m;
		public Pelicula(string titulo, Int16 año) {
			this.titulo = titulo;
			this.año = año;
		}
		public string duracion() {
			return String.Format("{0}h {1}m", duracion_h, duracion_m);
		}
	}
	class Cine
	{
		public string nombre;
		public bool proyectando = false;
		public Pelicula pelicula_proyectando;
		public Pelicula[] peliculas = new Pelicula[2];
		public Pelicula nulled = null;
		private int i = 0;
		public void AgregarPelicula(in Pelicula pelicula)
		{
			peliculas[i] = pelicula;
			i++;
		}
		public ref Pelicula BuscarPelicula(string titulo) {
			for(int i = 0; i <= this.i; i++) {
				if(peliculas[i].titulo != null && peliculas[i].titulo.ToLower() == titulo.ToLower())
					return ref peliculas[i];
			}
			return ref nulled;
		}
		public void BuscarPelicula(string titulo, out Pelicula pelicula) {
			pelicula = nulled;
			for(int i = 0; i <= this.i; i++) {
				if(peliculas[i].titulo != null && peliculas[i].titulo.ToLower() == titulo.ToLower()) {
					pelicula = peliculas[i];
					break;
				}
			}
		}
		public bool Proyectar(in Pelicula pelicula) {
			if(proyectando == true)
				return false;
			for(int i = 0; i < peliculas.Length-1; i++) {
				if(peliculas[i] == pelicula){
					pelicula_proyectando = peliculas[i];
					proyectando = true;
					return true;
				}
			}
			return false;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Cine cine = new Cine();
			cine.AgregarPelicula(new Pelicula("La La Land", 2016));
			// True = ref, False = value
			bool caso = true;
			if(caso == true) {
				cine.nombre = "Cinepolis";
				ref Pelicula pelicula = ref cine.BuscarPelicula("la la land");
				pelicula.pais = "Estados Unidos";
				pelicula.director = "Damien Chazelle";
				pelicula.duracion_h = 2;
				pelicula.duracion_m = 8;
				cine.Proyectar(pelicula);
				Console.WriteLine("Proyectando '{0}' ({1}) de {2} (Duracion: {3})", cine.pelicula_proyectando.titulo, cine.pelicula_proyectando.año, cine.pelicula_proyectando.director, cine.pelicula_proyectando.duracion());
			} else {
				cine.nombre = "Cinepolis Rojo";
				Pelicula peli;
				cine.BuscarPelicula("La La Land", out peli);
				peli.titulo = "La forma del agua";
				peli.año += 1;
				cine.AgregarPelicula(peli);
				cine.Proyectar(peli);
				Console.WriteLine("Proyectando '{0}' ({1})", cine.pelicula_proyectando.titulo, cine.pelicula_proyectando.año);
			}
		}
	}
}
