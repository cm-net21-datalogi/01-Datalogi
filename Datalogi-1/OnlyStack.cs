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
	public class OnlyStack<T> : ISimpleStack<T> where T:struct
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


		public int existsLoopCounter;
		public bool Exists(Predicate<T> condition) {
			existsLoopCounter = 0;
			// T är en värdetyp
			if (Head == null)
				return false;

			var node = Head;
			while(node != null)
			{
				existsLoopCounter++;
				bool result = condition(node.Data);
				if (result) return true;
				node = node.Next;
			}
			return false;
		}
		public bool ExistsRecursive(Predicate<T> condition)
		{
			return ExistsInRestOfStack(Head, condition);
		}
		private static bool ExistsInRestOfStack(MyNode<T>? node, Predicate<T> condition) {
			if (node == null) return false;

			if (condition(node.Data)) return true;

			return ExistsInRestOfStack(node.Next, condition);
		}

	}
}
