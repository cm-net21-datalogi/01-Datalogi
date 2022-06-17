using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	// T   - helt allmän
	// where T : class  - referenstyp (objects)
	// where T : struct - värdetyp (int osv.)
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

		public bool Exists(Predicate<T> condition) {
			if (Head == null)
				return false; //throw new Exception("Stacken är tom");

			var node = Head;
			while(node != null)
			{
				bool result = condition(node.Data);
				if (result) return true;  // node.Data om vi arbetar med en referenstyp
				node = node.Next;
			}
			return false; //throw new Exception("Värdet finns inte i stacken");
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
