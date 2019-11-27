using System;
using System.Collections.Generic;

namespace Alumnos
{
	// Crear clase padre 'Alumno'
	class Alumno
	{
		// Crear atributo privados el cual solo se puede obtener desde clases hijos o objetos.
		private string nombre;
		private string num_control;

		// Crear atributo protegido 'semestre' y 'carrera'
		protected int semestre;
		protected string carrera;

		// Se crear un constructor para declarar las variables
		public Alumno(string n, string nc, int s, string c) {
			this.nombre = n;
			this.num_control = nc;
			this.semestre = s;
			this.carrera = c;
		}
		// Metodo virtual para su futuro remplazo en clases hijos
		public void Presentarse() {
			Console.WriteLine("Hola soy {0}, voy en el semestre #{1} y estoy estudiando {2}", nombre, semestre, carrera);
		}
		// Metodo virtual para su futuro remplazo en clases hijos
		public void Obligaciones() {
			Console.WriteLine("Tengo la obligación de estudiar!");
		}
	}
	class Licenciatura : Alumno
	{
		// Crear atributo booleano que detecte si hizo o no, servicio social.
		private bool servicio_s;
		private bool practicas;
		// Tomar como base el constructor, y realizar el propio de la clase, incluyendo la variable tipo bool.
		public Licenciatura(string n, string nc, int s, string c, bool ss, bool p) : base(n, nc, s, c) {
			this.servicio_s = ss;
			this.practicas = p;
		}
		// Redefinir el metodo Obligaciones con una nuevo metodo
		public new void Obligaciones() {
			// Guardar el texto principal en una variable
			string salida = "Tengo la obligación de estudiar";
			// Si no ha hecho el servicio social
			if(!this.servicio_s)
			{
				// Encontrar la diferencia de si en su semestre ya hizo cuando debio de haberlo entregado.
				int hacer_ss = 6 - this.semestre;
				// Si la resta da mayor a 0, quiere decir que ya debio haberlo hecho
				// De lo contrario, debe hacerlos
				if(hacer_ss > 0) {
					salida += ", entregar mis documentos del Servicio Social";
				} else {
					salida += ", hacer mi Servicio Social";
				}
			}
			// Si no ha hecho sus practicas
			if(!this.practicas)
			{
				// Encontrar la diferencia de si en su semestre ya hizo cuando debio de haberlo entregado.
				int hacer_p = 9 - this.semestre;
				// Si la resta da mayor a 0, quiere decir que ya debio haberlo hecho
				// De lo contrario, debe hacerlos
				if(hacer_p > 0) {
					salida += ", entregar mis documentos de mis Practicas Profesionales";
				} else {
					salida += ", hacer mis Practicas Profesionales";
				}
			}
			// Imprimir todas las obligaciones
			Console.WriteLine(salida);
		}
	}
	// Clase Posgrado heredado de clase Alumno
	class Posgrado : Alumno
	{
		// Crear atributo booleano que detecte si hizo o no, servicio social.
		protected bool investigacion;
		// Tomar como base el constructor, y realizar el propio de la clase, incluyendo la variable tipo bool.
		public Posgrado(string n, string nc, int s, string c, bool inv) : base(n, nc, s, c) {
			this.investigacion = inv;
		}
		// Redefinir el metodo Obligaciones con una nuevo metodo
		public new void Obligaciones() {
			// Si tiene el servicio social hecho..
			if(this.investigacion)
			{
				Console.WriteLine("Tengo la obligación de estudiar, lo bueno es que ya realice mi investigación de Posgrado");
			}
			// Si no hizo ha hecho el servicio social..
			else
			{
				// Encontrar la diferencia de si en su semestre ya hizo cuando debio de haberlo entregado.
				int hacer_ss = 9 - this.semestre;
				// Si la resta da mayor a 0, quiere decir que ya debio haberlo hecho
				// De lo contrario, debe hacerlos
				if(hacer_ss > 0) {
					Console.WriteLine("Tengo la obligación de estudiar y entregar mi investigación lo mas pronto posible!");
				} else {
					Console.WriteLine("Tengo la obligación de estudiar y hacer mi investigación de Posgrado!");
				}
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			// Crear diferentes objetos de clases, tanto no heredados como heredados.
			Alumno pablo = new Alumno("Pablo Espinoza", "18215087", 5, "Ing. Sistemas Computacionales");
			Licenciatura mario = new Licenciatura("Mario Rodriguez", "16212591", 8, "Lic. Contaduria", false, false);
			Posgrado alfonso = new Posgrado("Alfonso Perico", "16219478", 9, "Ing. Bioquimico", false);
			Console.WriteLine("> Presentación de alumnos <");
			Console.WriteLine("----------------");
			pablo.Presentarse();
			pablo.Obligaciones();
			Console.WriteLine("----------------");
			mario.Presentarse();
			mario.Obligaciones();
			Console.WriteLine("----------------");
			alfonso.Presentarse();
			alfonso.Obligaciones();
			Console.WriteLine("----------------");
		}
	}
}
