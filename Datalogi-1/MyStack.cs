using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class MyStack<T> : SimpleStack<T>, SimpleQueue<T>
	{
		// översta noden i stacken
		// Vi använder MyNode för att kunna ha både datan, och en referens till nästa nod i stacken
		// Stacken är tom från början, översta noden är NULL
		private MyNode<T> Top = null;  // motsvarar "first"
		private MyNode<T> Last = null;  // motsvarar "bottom"

		// Lägga till en ny nod överst i stacken
		public void Push(T value)
		{
			var oldTop = Top;
			Top = new MyNode<T>();
			Top.Data = value;
			if(Top != null)
			{
				Top.Next = oldTop;
			}else
			{
				Last = Top;
			}
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
				// Returnera värdet som tidigare toppnoden hade
				return value;
			}
		}

		public void AddLast(T value)
		{
			if(Last == null)
			{
				Push(value);
			} else
			{
				var oldLast = Last;
				Last = new MyNode<T>();
				Last.Data = value;
				oldLast.Next = Last;
			}
		}

		public T GetFirst()
		{
			// Top == First
			return Peek();
		}

		public void RemoveFirst()
		{
			Pop();
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
				node.Next = node.Next.Next;
			}
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
	// Vi behöver spara både datan och en referens till nästa nod, vi använder MyNode för det
	/*public class MyNode<T>
	{
		public T Data { get; set; }
		public MyNode<T> Next { get; set; }
	}*/

	// Dessa metoder måste vår datastruktur implementera för att få lov att kalla sig för stack
	public interface SimpleStack<T>
	{
		public void Push(T value);  // lägg till värde överst i stacken
		public T Pop();  // ta bort översta värdet från stacken
		public T Peek();  // titta på översta värdet i stacken
	}
	// Top == First
	public interface SimpleQueue<T>
	{
		public void AddLast(T value);
		public T GetFirst();
		public void RemoveFirst();
	}

}
