using System;

namespace G_Stack
{
	public class Stack <T>
	{
		readonly int m_Size;
		int m_StackPointer = 0;
		T[] m_Items;

		public Stack() : this(100) {}
		public Stack(int size)
		{
			m_Size = size;
			m_Items = new T[m_Size];
		}

		public void Push(T item)
		{
			if (m_StackPointer >= m_Size)
				throw new StackOverflowException();
			m_Items[m_StackPointer] = item;
			m_StackPointer++;
		}
		public void Push(T[] items)
		{
			foreach(T item in items) {
				if (m_StackPointer >= m_Size)
					throw new StackOverflowException();
				m_Items[m_StackPointer] = item;
				m_StackPointer++;
			}
		}
		public T Pop()
		{
			m_StackPointer--;
			if (m_StackPointer >= 0)
			{
				return m_Items[m_StackPointer];
			} else
			{
				m_StackPointer = 0;
				throw new InvalidOperationException("Cannot pop an empty stack");
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Stack<string> texto = new Stack<string>(3);
			texto.Push(new string[]{"Mundo!", " ", "Hola"});
			Console.WriteLine(texto.Pop()+texto.Pop()+texto.Pop());

			Stack<char> letras = new Stack<char>(4);
			letras.Push(new char[]{'a','l','o','H'});
			// Fix suma de char's a string
			Console.WriteLine(""+letras.Pop()+letras.Pop()+letras.Pop()+letras.Pop());

			Stack<int> numeros = new Stack<int>(4);
			numeros.Push(new int[]{9,1,0,2});
			// Fix suma de enteros a string
			Console.WriteLine(""+numeros.Pop()+numeros.Pop()+numeros.Pop()+numeros.Pop());
		}
	}
}