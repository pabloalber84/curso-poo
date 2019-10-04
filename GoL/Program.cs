using System;
using System.Collections.Generic;

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
			for(short i = 0; i < grid.Count; i++) {
				for(short j = 0; j < grid[i].Count; j++) {
					grid[i][j].actualizar_estado();
				}
			}
		}
		public void print() {
			string buff = "";
			for(short i = 0; i < grid.Count; i++) {
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
			Tablero GoL = new Tablero(10, 5);
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 0));
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 1));
			GoL.agrega(new Celula(Estado.viva, GoL, 2, 0));
			GoL.agrega(new Celula(Estado.viva, GoL, 2, 1));
			int input = 1;
			while(input == 1) {
				GoL.print();
				Console.Write("Presiona 1 para continuar: ");
				input = int.Parse(Console.ReadLine());
				if(input == 1) {
					GoL.actualizar();
					Console.Clear();
				}
			}
/*			GoL.print();
			GoL.agrega(new Celula(Estado.viva, GoL, 1, 2));
			GoL.actualizar();
			GoL.print();*/
		}
	}
}