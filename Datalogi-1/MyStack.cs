using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class MyStack<T> : ISimpleStack<T>, ISimpleQueue<T>
	{
		// översta noden i stacken
		// Vi använder MyNode för att kunna ha både datan, och en referens till nästa nod i stacken
		// Stacken är tom från början, översta noden är NULL
		private MyNode<T> Top = null;  // motsvarar "first"
		private MyNode<T> Last = null;  // motsvarar "bottom"

		private int length = 0;

		public int Length()
		{
			return length;
		}

		public void Print()
		{
			if (Top == null)
			{
				Console.WriteLine("Stacken är tom");
				return;
			}
			var node = Top;
			while (node != null)
			{
				// skriv ut
				// gå till nästa
				Console.WriteLine(node.Data);
				node = node.Next;
			}
		}
		public void PrintReverse()
		{
			if (Top == null)
			{
				Console.WriteLine("Stacken är tom");
				return;
			}
			var node = Last;
			while (node != null)
			{
				// skriv ut
				// gå till föregående
				Console.WriteLine(node.Data);
				node = node.Previous;
			}
		}

		// Lägga till en ny nod överst i stacken
		public void Push(T value)
		{
			var oldTop = Top;
			Top = new MyNode<T>();
			Top.Data = value;
			Top.Next = oldTop;
			if(oldTop == null)
			{
				Last = Top;
			}
			else
			{
				oldTop.Previous = Top;
			}
			length++;
		}
		// Returnera värdet i den nod som är överst i stacken
		public T Peek()
		{
			if (Top == null)
			{
				throw new Exception("Stacken är tom. Det finns inget värde att se.");
			}
			return Top.Data;
		}
		// Ta bort den översta noden i stacken. Nu blir den näst översta noden den nya toppnoden.
		public T Pop()
		{
			// Två möjligheter:
			// 1. stacken är tom
			// 2. stacken har minst en nod
			if (Top == null)
			{
				throw new Exception("Stacken är tom. Det finns inget värde att poppa.");
			}
			else
			{
				// Spara värdet från den översta noden
				T value = Top.Data;
				// Ändra så att Top pekar på nästa nod. Då kommer den första noden att tas bort av garbage collector
				Top = Top.Next;
				if (Top != null)
				{
					Top.Previous = null;
					// Det finns förmodligen en bug här!
				}
				length--;
				// Returnera värdet som tidigare toppnoden hade
				return value;
			}
		}

		public void AddLast(T value)
		{
			//Console.WriteLine("AddLast 1, " + length);
			if (Last == null)
			{
				Push(value);
				//Console.WriteLine("AddLast 2a, " + length);
			}
			else
			{
				var oldLast = Last;
				Last = new MyNode<T>();
				Last.Data = value;
				oldLast.Next = Last;
				Last.Previous = oldLast;
				//Console.WriteLine("AddLast 2b, " + length);
				length++;
			}
			//Console.WriteLine("AddLast 4, " + length);

		}

		public T GetFirst()
		{
			// Top == First
			return Peek();
		}

		public T GetAt(int index)
		{
			if (index < 0) throw new Exception("Felaktigt index");

			// GetAt är samma sak som: array[index]
			var node = Top;
			while(index > 0 && node != null)
			{
				node = node.Next;
				index--;
			}
			if (node == null)
				throw new Exception("Index utanför stacken");

			return node.Data;
		}

		public void SetAt(int index, T value)
		{
			if (index < 0) throw new Exception("Felaktigt index");

			// SetAt är samma som: array[index] = value
			var node = Top;
			while (index > 0 && node != null)
			{
				node = node.Next;
				index--;
			}
			if (node == null)
				throw new Exception("Index utanför stacken");

			node.Data = value;
		}

		public void RemoveLast()
		{
			Pop();
		}
		public void RemoveFirst()
		{
			if (Top == null)
			{
				throw new Exception("Stacken är tom, kan inte ta bort första noden.");
			}
			var node = Top;
			while(node.Next.Next != null)
			{
				node = node.Next;
			}
			node.Next = null;
			length--;
		}

		public void RemoveAt(int index)
		{
			// Vi behöver göra olika saker beroende på hur många noder det finns i listan
			// Kontrollera index - får inte vara negativt
			// Kan bara fortsätta om listan inte är tom

			// Listan har 1 nod
			// Listan har 2 noder
			// osv.

			if (index < 0)
			{
				throw new Exception("Index måste vara minst noll.");
			}
			else if (Top == null)
			{
				throw new Exception("Stacken är tom, det går inte att ta bort några noder.");
			}
			else if (Top.Next == null && index == 0)
			{
				Top = null;
				Last = null;
			}
			else if (Top.Next == null && index > 0)
			{
				throw new Exception("Kan inte ta bort, stacken har inte så många element.");
			}
			else if( index== 0)
			{
				Top = Top.Next;
				if (Top == null) Last = null;
			} else
			{
				MyNode<T> node = Top;
				while (index > 1)
				{
					node = node.Next;
					index--;
					if (node == null)
					{
						throw new Exception("Kan inte ta bort, stacken har inte så många element.");
					}
				}
				// Nu ska vi ta bort noden som "node.Next" refererar till
				if (node.Next == null)
				{
					throw new Exception("Kan inte ta bort, stacken har inte så många element.");
				}
				var node1 = node;
				//var nodeToRemove = node.Next;
				var node3 = node.Next.Next;
				node1.Next = node3;
				node3.Previous = node1;
			}

			length--;
			// index 0 är första noden
			// index 1 är andra noden
			// osv...
			// index 500000 är nod nr 500001
			/*RemoveAt(500000);  // inte säkert att det finns 500000 noder
			RemoveAt(1);  // kanske inte finns 2
			RemoveAt(0);  // kanske inte ens finns 1
			RemoveAt(-1); // aldrig okej */
		}
	}

}
