using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class OnlyStack<T> : ISimpleStack<T>
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
	}
}
