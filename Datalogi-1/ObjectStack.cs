using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	// bara T   <- helt allmän generisk datatyp
	// where T : class  <- referenstyp (objects)
	// where T : struct <- värdetyp (int osv.)
	public class ObjectStack<T> : ISimpleStack<T> where T:class
	{
		private MyNode<T>? Head = null;
		public T Peek()
		{
			if (Head == null)
				throw new Exception("Stacken är tom");
			else
				return Head.Data;
		}

		public T Pop()
		{
			if (Head == null)
				throw new Exception("Stacken är tom");
			var data = Head.Data;
			Head = Head.Next;
			return data;
		}

		public void Push(T value)
		{
			var oldHead = Head;
			Head = new MyNode<T>();
			Head.Data = value;
			Head.Next = oldHead;
		}


		public int loopCounter;
		public T? Find(Predicate<T> condition) {
			// kontrollera om stacken är tom
			// iterera över alla element i stacken
			// om något element uppfyller villkoret: returnera det
			// räkna antalet varv i loopen
			loopCounter = 0;

			if (Head == null)
				return null;

			var node = Head;
			while (node != null)
			{
				loopCounter++;
				// Predicate<T> är en anonym funktion
				bool result = condition(node.Data);
				if (result)
					return node.Data;

				node = node.Next;
			}
			return null;
		}

		//public T? FindBinary(Predicate<T> condition) { }
	}
}
