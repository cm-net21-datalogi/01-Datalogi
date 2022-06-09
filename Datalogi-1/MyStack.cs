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
