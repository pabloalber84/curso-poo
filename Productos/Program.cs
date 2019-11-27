using System;
using System.IO;
using System.Collections.Generic;

namespace Productos
{
	class Producto : IComparable<Producto>
	{
		public string codigo, descripcion;
		public double precio;
		public int departamento, likes = 0;

		public Producto(string c, string d, double p, int depa, int l=0) {
			codigo = c;
			descripcion = d;
			precio = p;
			departamento = depa;
			likes = l;
		}
		public int CompareTo(Producto obj)
		{
			if (obj == null)
				return 1;
			return obj.likes.CompareTo(this.likes);
		}
	}
	class ProductoDB
	{
		public List<Producto> productos = new List<Producto>();
		private string archivo;
		public ProductoDB(string a = @"productos") {
			archivo = a;
		}
		public void Parse() {
			this.Empty();
			try {
				using(StreamReader sr = new StreamReader(@archivo+".txt"))
				{
					string line = "";
					while ((line = sr.ReadLine()) != null) // No lleguemos al final del archivo
					{
						string[] columnas = line.Split('|');
						if(columnas.Length < 5)
							continue;
						productos.Add(new Producto(columnas[0], columnas[1], Double.Parse(columnas[2]), int.Parse(columnas[3]), int.Parse(columnas[4])));
					}

				}
			} catch(FileNotFoundException) {
				File.Create(@archivo+".txt").Dispose();
				if (!File.Exists(@archivo+".dat"))
					File.Create(@archivo+".dat").Dispose();
			} catch(IOException ex) {
				Console.WriteLine("Error al leer el archivo: "+ex.Message);
			}
		}
		public int AddFrom(string file) {
			int c = 0;
			try {
				using(StreamReader sr = new StreamReader(@file))
				{
					string line = "";
					while ((line = sr.ReadLine()) != null) // No lleguemos al final del archivo
					{
						string[] columnas = line.Split('|');
						if(columnas.Length < 5)
							continue;
						productos.Add(new Producto(columnas[0], columnas[1], Double.Parse(columnas[2]), int.Parse(columnas[3]), int.Parse(columnas[4])));
						c++;
					}

				}
			} catch(FileNotFoundException) {
				Console.WriteLine("Error al leer el archivo: No existe el archivo ingresado");
			} catch(IOException ex) {
				Console.WriteLine("Error al leer el archivo: "+ex.Message);
			}
			return c;
		}
		public void Write() {
			using(StreamWriter writter = new StreamWriter(new FileStream(@archivo+".txt", FileMode.OpenOrCreate, FileAccess.Write))) {
				foreach(Producto p in productos) {
					writter.WriteLine("{0}|{1}|{2}|{3}|{4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
				}
				if(productos.Count < 1)
					writter.WriteLine("");
			}
			using(BinaryWriter writter = new BinaryWriter(new FileStream(@archivo+".dat", FileMode.OpenOrCreate))) {
				foreach(Producto p in productos) {
					writter.Write(String.Format("{0}|{1}|{2}|{3}|{4}\r\n", p.codigo, p.descripcion, p.precio, p.departamento, p.likes));
				}
				if(productos.Count < 1)
					writter.Write("");
			}
		}
		public void Empty() {
			productos = new List<Producto>();
		}
		public void GetDepartment(int Depto) {
			int c = 0;
			Console.WriteLine("[Departamento #{0}]", Depto);
			foreach(Producto p in productos) {
				c++;
				if(p.departamento == Depto) {
					Console.WriteLine("[Producto #{0}] '{1}' con clave '{2}' tiene un costo de ${3} ({4} Likes)", c, p.descripcion, p.codigo, p.precio, p.likes);
				}
			}
		}
		public void OrderByLikes() {
			int c = 0;
			Console.WriteLine("Orden por likes:");
			productos.Sort();
			foreach(Producto p in productos) {
				c++;
				Console.WriteLine("[Producto #{0}][D: {1}] '{2}' con clave '{3}' tiene un costo de ${4} ({5} Likes)", c, p.departamento, p.descripcion, p.codigo, p.precio, p.likes);
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
/*
			ProductoDB database = new ProductoDB();
			database.Parse();
			database.Empty();
			// Departamento de Ropa
			database.productos.Add(new Producto("ADL 315", "Pantalon largo azul", 200.00d, 1, 15));
			database.productos.Add(new Producto("ADH 317", "Pantalon mediano azul", 150.00d, 1, 8));
			database.productos.Add(new Producto("ADD 319", "Pantalon corto azul", 125.00d, 1, 7));
			// Departamento de Papeleria
			database.productos.Add(new Producto("PBG 129", "Borrador blanco", 10.00d, 2, 50));
			database.productos.Add(new Producto("PBC 315", "Lapiz #2", 2.00d, 2, 120));
			database.productos.Add(new Producto("PBA 118", "Sacapuntas Metal", 20.00d, 2, 75));
			//database.GetDepartament(1);
			database.OrderByLikes();
			database.Write();*/
			ProductoDB database = new ProductoDB();
			database.Parse();
			Console.Write("Ingrese el nombre del archivo a importar: ");
			string archivo = Console.ReadLine();
			database.AddFrom(archivo);
			database.OrderByLikes();
			database.Write();
		}
	}
}