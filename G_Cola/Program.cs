using System;

namespace G_Cola
{
	public class Cola <T>
	{
		readonly int m_Size;
		int m_Pointer = 0;
		T[] m_Items;

		public Cola() : this(100) {}
		public Cola(int size)
		{
			m_Size = size;
			m_Items = new T[m_Size];
		}

		public void Push(T item)
		{
			if (m_Pointer >= m_Size)
				throw new StackOverflowException();
			m_Items[m_Pointer] = item;
			m_Pointer++;
		}
		public void Push(T[] items)
		{
			foreach(T item in items) {
				if (m_Pointer >= m_Size)
					throw new StackOverflowException();
				m_Items[m_Pointer] = item;
				m_Pointer++;
			}
		}
		public T Pop()
		{
			if (m_Pointer <= m_Size)
			{
                // Guardar el primer valor de acuerdo a reglas FIFO (First In First Out)
                T o = (T)m_Items[0];
                // Crear un backup, donde sera almacenada el nuevo array
                T[] b = new T[m_Size];
                // Pasar del indice 1 (Indice 0 removido) hacia donde este el apuntador menos 1
                for(int i = 1; i < m_Pointer; i++) {
                    // Recorrer en el respaldo 1 para que el indice 1 sea 0, el 2 sea 1, así consecutivamente
                    b[i-1] = m_Items[i];
                }
                // Establecer nueva cola.
                m_Items = b;
                // Restarle uno al apuntador
                m_Pointer--;
                // Retornar el primer valor que tenia que salir, osease, el eliminado.
				return o;
			} else
			{
				m_Pointer = 0;
				throw new InvalidOperationException("No puedes romper mas la cola!");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Cola<string> texto = new Cola<string>(3);
			texto.Push(new string[]{"Hola", " ", "Mundo!"});
			Console.WriteLine(texto.Pop()+texto.Pop()+texto.Pop());

			Cola<char> letras = new Cola<char>(4);
			letras.Push(new char[]{'H', 'o', 'l', 'a'});
			// Fix suma de char's a string
			Console.WriteLine(""+letras.Pop()+letras.Pop()+letras.Pop()+letras.Pop());

			Cola<int> numeros = new Cola<int>(4);
			numeros.Push(new int[]{2, 0, 1, 9});
			// Fix suma de enteros a string
			Console.WriteLine(""+numeros.Pop()+numeros.Pop()+numeros.Pop()+numeros.Pop());
		}
	}
}