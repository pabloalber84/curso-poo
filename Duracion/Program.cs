using System;

namespace Duracion
{
	class Duracion
	{
		// Atributos
		// Milisegundos va a manejar los milisegundos totales.
		private double _milisegundos;
		// Encapsulamiento para que solamente se pueda obtener la cantidad en milisegundos, pero no establecer.
		public double milisegundos {
			get
			{
				return _milisegundos;
			}
		}
		// Constructor para establecer la variable _milisegundos con parametro único tipo double en segundos
		public Duracion(double segundos) {
			_milisegundos = segundos/1000;
		}
		// Constructor para establecer la variable _milisegundos con parametros tipo int de acuerdo a las horas, minutos y segundos
		public Duracion(int horas, int minutos, int segundos) {
			// Se establece a 0
			_milisegundos = 0;
			// Se le hacen las sumas convertidas a milisegundos de acuerdo a su medida
			// (1 segundos = 1000 milisegundos, 1 minuto = 60 segundos, 1 hora = 60 minutos)
			_milisegundos += 1000*60*60*horas;
			_milisegundos += 1000*60*minutos;
			_milisegundos += 1000*segundos;
		}
		// Convierte los milisegundos a días totales no redondeados.
		public double toDays() {
			return Math.Floor( (_milisegundos/(1000*60*60*24)));
		}
		// Convierte los milisegundos a horas totales no redondeados.
		public double toHours() {
			return Math.Floor( (_milisegundos/(1000*60*60)));
		}
		// Convierte los milisegundos a minutos totales no redondeados.
		public double toMins() {
			return Math.Floor( (_milisegundos/(1000*60)));
		}
		// Convierte los milisegundos a segundos totales no redondeados.
		public double toSegs() {
			return Math.Floor( (_milisegundos/(1000)));
		}
		// Sobrecarga de operadores para sumar dos duraciones y retornar una duracion.
		public static Duracion operator +(Duracion a, Duracion b) {
			return new Duracion((a.milisegundos+b.milisegundos)*1000);
		}
		// Metodo que imprime en formato.
		public void Imprimir() {
			// Primero obtiene los dias no redondeados de los milisegundos.
			double dias = toDays();
			// Se transforma la cantidad de milisegundos a horas, restandole los milisegundos ya usados que convertirmos a días antes de hacer la división.
			double horas = Math.Floor((_milisegundos-(1000*60*60*24*dias))/(1000*60*60));
			// Se transforma la cantidad de milisegundos a minutos, restandole los milisegundos ya usados que convertirmos anteriormente antes de hacer la división.
			double minutos = Math.Floor((_milisegundos-(1000*60*60*24*dias)-(1000*60*60*horas))/(1000*60));
			// Se transforma la cantidad de milisegundos a segundos, restandole los milisegundos ya usados que convertirmos anteriormente antes de hacer la división.
			double segundos = Math.Floor((_milisegundos-(1000*60*60*24*dias)-(1000*60*minutos)-(1000*60*60*horas))/1000);
			// Se imprime con un formato especifico.
			Console.WriteLine("{0} d | {1} hrs | {2} mins | {3} segs", dias, horas, minutos, segundos);
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			// Se llaman crean 2 efectos totalmente diferentes.
			Duracion tiempo_1 = new Duracion(24, 0, 0);
			Duracion tiempo_2 = new Duracion(1, 1, 1);
			// Se imprimen ambas duraciones.
			tiempo_1.Imprimir();
			tiempo_2.Imprimir();
			// Se imprime la suma de ambos.
			(tiempo_1+tiempo_2).Imprimir();
		}
	}
}
