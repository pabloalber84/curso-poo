using System;
using System.Collections.Generic;
using System.Threading;

namespace gol
{
	enum Estado { viva, muerta}
	class Celula {
		public Estado estado_actual;
		public Estado estado_siguiente;
		public Tablero tablero;
		public short renglon;
		public short columna;
		
		public Celula(Estado inicial, Tablero tablero , short renglon, short columna)
		{
			estado_actual = inicial;
			estado_siguiente = inicial;
			this.tablero = tablero;
			this.renglon = renglon;
			this.columna = columna;
		}
		public char symbol() {
			if(estado_actual == Estado.viva)
				return '█';
			else
				return '▒';
		}
		public void actualizar() {
			short num_vecinas = vecinas();
			if(estado_actual == Estado.viva && (num_vecinas < 2 || num_vecinas > 3)) {
				estado_siguiente = Estado.muerta;
			}
			if(estado_actual == Estado.muerta && num_vecinas == 3) {
				estado_siguiente = Estado.viva;
			}
		}
		public void actualizar_estado() {
			estado_actual = estado_siguiente;
		}
		public short vecinas() {
			short c = 0;
			// Verificar las celulas vecinas en un orden de las 8 alrededor de ELLA:
			// XXX
			// XOX
			// XXX
			// Renglon anterior
			if(renglon > 0) {
				if(columna > 0 && tablero.cell_in_pos(renglon-1, columna-1).estado_actual == Estado.viva)
					c++;
				if(tablero.cell_in_pos(renglon-1, columna).estado_actual == Estado.viva)
					c++;
				if(columna < tablero.num_columnas-1 && tablero.cell_in_pos(renglon-1, columna+1).estado_actual == Estado.viva)
					c++;
			}
			// Renglon actual
			if(columna > 0 && tablero.cell_in_pos(renglon, columna-1).estado_actual == Estado.viva)
				c++;
			if(columna < tablero.num_columnas-1 && tablero.cell_in_pos(renglon, columna+1).estado_actual == Estado.viva)
				c++;

			// Renglon siguiente
			if(renglon < tablero.num_renglones-1) {
				if(columna > 0 && tablero.cell_in_pos(renglon+1, columna-1).estado_actual == Estado.viva)
					c++;
				if(tablero.cell_in_pos(renglon+1, columna).estado_actual == Estado.viva)
					c++;
				if(columna < tablero.num_columnas-1 && tablero.cell_in_pos(renglon+1, columna+1).estado_actual == Estado.viva)
					c++;
			}
			return c;
		}
	}

	class Tablero {
		private List<List<Celula>>  grid;
		private short _num_renglones;
		private short _num_columnas;
		public short num_renglones {
			get {
				return _num_renglones;
			}
		}
		public short num_columnas {
			get {
				return _num_columnas;
			}
		}
		public Tablero(short num_renglones, short num_columnas) {
			_num_renglones = num_renglones;
			_num_columnas = num_columnas;
			grid = new List<List<Celula>>();
			for(short i = 0; i < num_renglones; i++) {
				grid.Add(new List<Celula>());
				for(short j = 0; j < num_columnas; j++) {
					grid[i].Add(new Celula(Estado.muerta, this, i, j));
				}
			}
		}
		public void agrega(Celula cell) {
			if((cell.renglon >= 0 && cell.renglon <= num_renglones) && (cell.columna >= 0 && cell.columna <= num_columnas))
				grid[cell.renglon][cell.columna] = cell;
		}
		public void agrega_map(short [,] pos) {
			for(int i = 0; i < pos.GetLength(0); i++) {
				agrega(new Celula(Estado.viva, this, pos[i, 0], pos[i, 1]));
			}
		}
		public Celula cell_in_pos(int renglon, int columna) {
			if(!(renglon >= 0 && renglon < num_renglones))
				throw new ArgumentException("El renglon especificado esta fuera del rango ("+renglon+", MAX "+num_renglones+") Params: ("+renglon+", "+columna+")", "renglon");
			else if(!(columna >= 0 && columna < num_columnas))
				throw new ArgumentException("La columna especificada esta fuera del rango ("+columna+", MAX "+num_columnas+") Params: ("+renglon+", "+columna+")", "columna");
			else
				return grid[renglon][columna];
		}
		public void actualizar(){
			for(short i = 0; i < grid.Count; i++) {
				for(short j = 0; j < grid[i].Count; j++) {
					grid[i][j].actualizar();
				}
			}
		}
		public void siguiente_turno() {
			for(short i = 0; i < grid.Count; i++) {
				for(short j = 0; j < grid[i].Count; j++) {
					grid[i][j].actualizar_estado();
				}
			}
		}
		public void print(bool show_pos = false) {
			string buff = "";
			if(show_pos)
				buff+="   x\n   _\ny |";
			for(short i = 0; i < grid.Count; i++) {
				if(show_pos && i != 0)
					buff+="   ";
				for(short j = 0; j < grid[i].Count; j++) {
					buff += grid[i][j].symbol();
				}
				buff += "\n";
			}
			Console.WriteLine(buff);
		}
	}


	class Program
{
		static void Main(string[] args)
		{
/*			Tablero GoL = new Tablero(10, 5);
			GoL.agrega(new Celula(Estado.viva, GoL, 0, 0));
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 1));
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 2));
			GoL.agrega(new Celula(Estado.viva, GoL, 2, 1));
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 2));*/
			Tablero GoL = new Tablero(15, 40);
			short[,] glider_gun = new short[,] {
				{0, 24},
				{1, 22}, {1, 24},
				{2, 12}, {2, 13}, {2, 20}, {2, 21}, {2, 34}, {2, 35},
				{3,11}, {3,15}, {3,20}, {3,21}, {3,34}, {3,35},
				{4,0}, {4,1}, {4,10}, {4,16}, {4,20}, {4,21},
				{5,0}, {5,1}, {5,10}, {5,14}, {5,16}, {5,17}, {5,22}, {5, 24},
				{6,10}, {6,16}, {6,24},
				{7,11}, {7,15},
				{8,12}, {8,13}
			};
			GoL.agrega_map(glider_gun);
			int input = 1;
			while(input == 1)
			{
				Console.Clear();
				Console.WriteLine("Tablero de juego");
				GoL.print(true);
				Console.Write("Presiona 1 para el siguiente turno, 2 para modificar el tablero o 3 para adelantar 10 turnos: ");
				input = int.Parse(Console.ReadLine());
				if(input == 1) {
					GoL.actualizar();
					GoL.siguiente_turno();
				} else if(input == 2) {
					InvalidPos:
					Console.Write("Ingrese las posiciones de la celula en formato 'x,y,viva': ");
					var pos = Console.ReadLine().Split(",");
					if(pos.Length != 3)
					{
						Console.WriteLine("Deben ser 3 parametros en formato 'x,y,viva', ejemplo: 5,2,1");
						goto InvalidPos;
					} else {
						short x = short.Parse(pos[0]);
						short y = short.Parse(pos[1]);
						string estado = pos[2];
						if(!(x >= 0 && x < GoL.num_renglones)) {
							Console.WriteLine("El renglon especificado esta fuera de los alcances del tablero.");
							goto InvalidPos;
						} else if(!(y >= 0 && y < GoL.num_columnas)) {
							Console.WriteLine("El renglon especificado esta fuera de los alcances del tablero.");
							goto InvalidPos;
						} else if(estado != "1" && estado != "0" && estado != "false" && estado != "true") {
							Console.WriteLine("El renglon especificado esta fuera de los alcances del tablero.");
							goto InvalidPos;
						} else {
							input = 1;
							bool viva = false;
							if(estado == "1" || estado == "true")
								viva = true;
							GoL.agrega(new Celula((viva ? Estado.viva : Estado.muerta), GoL, x, y));
						}
					}
				} else if(input == 3) {
					int tick = 150;
					int ticks = 50;
					for(int i = 0; i < ticks; i++) {
						Console.Clear();
						GoL.print(true);
						GoL.actualizar();
						GoL.siguiente_turno();
						Thread.Sleep(tick);
					}
					input = 1;
				}
			}
			Console.WriteLine("Gracias por jugar el 'Juego de la Vida'");
		}
	}
}