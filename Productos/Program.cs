/*
	* Proyecto 5,6
	* Nombre: Productos
	* Fecha: 02/12/2019
	* Revisió: 1.2
	* Alumno: Pablo Alberto Espinoza Ruiz
	* Maestro: Mario García Valdez
	* Carrera: Ingenieria en Sistemas Computacionales
	* Clase: Programación Orientada a Objetos
	* Institución: ITT
*/
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Productos
{
	public class Producto
	{
		public string codigo {get; set;}
		public string descripcion {get; set;}
		public double precio {get; set;}
		public int departamento {get; set;}
		public int likes {get; set;}

		public Producto(string c, string d, double p, int depa, int l=0) {
			codigo = c;
			descripcion = d;
			precio = p;
			departamento = depa;
			likes = l;
		}
	}
	public enum FileType {
		Text,
		Binary,
		JSON
	}
	public static class ProductoDB
	{
		public static List<Producto> Parse(string file, FileType t = FileType.Text) {
			switch(t) {
				case FileType.Text:
					return ParseTXT(file);
				case FileType.Binary:
					return ParseBIN(file);
				case FileType.JSON:
					return ParseJSON(file);
				default:
					return new List<Producto>();
			}
		}
		private static List<Producto> ParseTXT(string file) {
			List<Producto> productos = new List<Producto>();
			try {
				if(!file.ToLower().Contains(".txt"))
					throw new IOException("Formato de archivo no correcto (necesario '.txt')");
				using(StreamReader sr = new StreamReader(file))
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
				Console.WriteLine("Error al leer el archivo ({0}): No se encontro el archivo!", file);
			} catch(IOException ex) {
				Console.WriteLine("Error al leer el archivo ({0}): {1}", file, ex.Message);
			}
			return productos;
		}
		private static List<Producto> ParseBIN(string file) {
			List<Producto> productos = new List<Producto>();
			try {
				if(!file.ToLower().Contains(".bin"))
					throw new IOException("Formato de archivo no correcto (necesario '.bin')");
				using(BinaryReader sr = new BinaryReader(new FileStream(file, FileMode.Open, FileAccess.Read)))
				{
					while (sr.PeekChar() != -1) // No lleguemos al final del archivo
					{
						productos.Add(new Producto(sr.ReadString(), sr.ReadString(), sr.ReadDouble(), sr.ReadInt32(), sr.ReadInt32()));
					}

				}
			} catch(FileNotFoundException) {
				Console.WriteLine("Error al leer el archivo ({0}): No se encontro el archivo!", file);
			} catch(IOException ex) {
				Console.WriteLine("Error al leer el archivo ({0}): {1}", file, ex.Message);
			}
			return productos;
		}
		private static List<Producto> ParseJSON(string file) {
			List<Producto> productos = new List<Producto>();
			try {
				if(!file.ToLower().Contains(".txt"))
					throw new IOException("Formato de archivo no correcto (necesario '.txt')");
				using(StreamReader sr = new StreamReader(file))
				{
					using (JsonDocument document = JsonDocument.Parse(sr.ReadToEnd(), new JsonDocumentOptions { AllowTrailingCommas = true }))
					{
						foreach (JsonElement element in document.RootElement.EnumerateArray())
						{
							productos.Add(new Producto(element.GetProperty("codigo").GetString(), element.GetProperty("descripcion").GetString(), element.GetProperty("precio").GetDouble(), element.GetProperty("departamento").GetInt32(), element.GetProperty("likes").GetInt32()));
						}
					}
				}
			} catch(FileNotFoundException) {
				Console.WriteLine("Error al leer el archivo ({0}): No se encontro el archivo!", file);
			} catch(JsonException) {
				Console.WriteLine("Error al leer el archivo ({0}): Error de formato JSON", file);
			}
			return productos;
		}
		public static void Write(string file, List<Producto> productos, FileType t = FileType.Text) {
			switch(t) {
				case FileType.Text:
					WriteTXT(file, productos);
					break;
				case FileType.Binary:
					WriteBIN(file, productos);
					break;
				case FileType.JSON:
					WriteJSON(file, productos);
					break;
			}
		}
		private static void WriteTXT(string file, List<Producto> productos) {
			try {
				if(!file.ToLower().Contains(".txt"))
					throw new IOException("Formato de archivo no correcto (necesario '.txt')");
				using(StreamWriter writter = new StreamWriter(new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))) {
					foreach(Producto p in productos) {
						writter.WriteLine("{0}|{1}|{2}|{3}|{4}", p.codigo, p.descripcion, p.precio, p.departamento, p.likes);
					}
				}
			} catch(IOException ex) {
				Console.WriteLine("Error al escribir el archivo ({0}): {1}", file, ex.Message);
			}
		}
		private static void WriteBIN(string file, List<Producto> productos) {
			try {
				if(!file.ToLower().Contains(".bin"))
					throw new IOException("Formato de archivo no correcto (necesario '.bin')");
				using(BinaryWriter writter = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))) {
					foreach(Producto p in productos) {
						writter.Write(p.codigo);
						writter.Write(p.descripcion);
						writter.Write(p.precio);
						writter.Write(p.departamento);
						writter.Write(p.likes);
					}
				}
			} catch(IOException ex) {
				Console.WriteLine("Error al escribir el archivo ({0}): {1}", file, ex.Message);
			}
		}
		private static void WriteJSON(string file, List<Producto> productos) {
			try {
				if(!file.ToLower().Contains(".json"))
					throw new IOException("Formato de archivo no correcto (necesario '.json')");
				using(StreamWriter writter = new StreamWriter(new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))) {
					writter.WriteLine(JsonSerializer.Serialize(productos));
				}
			} catch(IOException ex) {
				Console.WriteLine("Error al escribir el archivo ({0}): {1}", file, ex.Message);
			}
		}
		public static void GetDepartment(int Depto, string file) {
			List<Producto> productos;
			if(file.ToLower().Contains(".txt")) {
				productos = ParseTXT(file);
			} else if(file.ToLower().Contains(".bin")) {
				productos = ParseBIN(file);
			} else if(file.ToLower().Contains(".json")) {
				productos = ParseJSON(file);
			} else {
				Console.WriteLine("Error al leer el archivo ({0}): Formato desconocido.", file);
				return;
			}
			IEnumerable<Producto> productoQuery =
				from p in productos
				where p.departamento == Depto
				select p;
			int c = 0;
			Console.WriteLine("[Departamento #{0}]", Depto);
			foreach(Producto p in productoQuery) {
				c++;
				Console.WriteLine("[Producto #{0}] '{1}' con clave '{2}' tiene un costo de ${3} ({4} Likes)", c, p.descripcion, p.codigo, p.precio, p.likes);
			}
		}
		public static void OrderByLikes(string file) {
			List<Producto> productos;
			if(file.ToLower().Contains(".txt")) {
				productos = ParseTXT(file);
			} else if(file.ToLower().Contains(".bin")) {
				productos = ParseBIN(file);
			} else if(file.ToLower().Contains(".json")) {
				productos = ParseJSON(file);
			} else {
				Console.WriteLine("Error al leer el archivo ({0}): Formato desconocido.", file);
				return;
			}
			IEnumerable<Producto> productoQuery =
				from p in productos
				orderby p.likes
				select p;
			int c = 0;
			Console.WriteLine("Orden por likes:");
			foreach(Producto p in productoQuery) {
				c++;
				Console.WriteLine("[Producto #{0}] '{1}' con clave '{2}' tiene un costo de ${3} ({4} Likes)", c, p.descripcion, p.codigo, p.precio, p.likes);
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			{
				List<Producto> productos = new List<Producto>();
				productos.Add(new Producto("ADL 315", "Pantalon largo azul", 200.00d, 1, 15));
				productos.Add(new Producto("ADH 317", "Pantalon mediano azul", 150.00d, 1, 8));
				productos.Add(new Producto("ADD 319", "Pantalon corto azul", 125.00d, 1, 7));
				productos.Add(new Producto("PBG 129", "Borrador blanco", 10.00d, 2, 50));
				productos.Add(new Producto("PBC 315", "Lapiz #2", 2.00d, 2, 120));
				productos.Add(new Producto("PBA 118", "Sacapuntas Metal", 20.00d, 2, 75));
				//------- Ejemplo 1. Debes guardar los datos en un archivo tipo TEXTO. -----------\\
				ProductoDB.Write(@"archivos\productos.txt", productos, FileType.Text);
				//------- Ejemplo 2. También en un archivo tipo BINARIO. -----------\\
				ProductoDB.Write(@"archivos\productos.bin", productos, FileType.Binary);
				//------- Ejemplo EXTRA. En un archivo tipo JSON. -----------\\
				ProductoDB.Write(@"archivos\productos.json", productos, FileType.JSON);
				//------- Ejemplo 3. Haz un método llamado GetDepartment(int Depto) que lea los productos del archivo... -----------\\
				ProductoDB.GetDepartment(1, @"archivos\productos.txt");
				//------- Ejemplo 4. Haz un método que lea los Productos de un archivo y los ordene por Likes, después los muestre en la consola. -----------\\
				ProductoDB.OrderByLikes(@"archivos\productos.txt");
				//------- Ejemplo 5. Haz un programa que agregue los productos de un archivo en otro archivo ya existente. -----------\\
				List<Producto> productos_nuevos = new List<Producto>();
				productos_nuevos.Add(new Producto("MXB 293", "Refresco Coca Cola 600ml", 15.00d, 3, 600));
				productos_nuevos.Add(new Producto("MXB 826", "Refresco Pepsi 600ml", 15.00d, 3, 429));
				productos_nuevos.Add(new Producto("MXB 375", "Agua mineral Bonfanot 1lt", 12.00d, 3, 700));
				productos_nuevos.Add(new Producto("MXB 164", "Refresco Mirinda 600ml", 15.00d, 3, 215));
				ProductoDB.Write(@"archivos\productos_nuevos.txt", productos, FileType.Text);
			}
			Console.WriteLine("Productos actuales y nuevos escritos, presiona cualquier\ntecla para agregar los productos nuevos a los actuales");
			Console.ReadKey(false);
			{
				List<Producto> productos, productos_nuevos;
				productos = ProductoDB.Parse(@"archivos\productos.txt"); // Parametro por defecto = FileType.Text
				productos_nuevos = ProductoDB.Parse(@"archivos\productos_nuevos.txt"); // Parametro por defecto = FileType.Text
				productos.AddRange(productos_nuevos.ToArray()); // Convertir en array convencional Producto[], y agregarlos todos a la vez en productos.
				ProductoDB.Write(@"archivos\productos.txt", productos);
			}
			Console.WriteLine("NUEVOS PRODUCTOS AGREGADOS! Consulta productos.txt dentro de la carpeta 'archivos'");
		}
	}
}