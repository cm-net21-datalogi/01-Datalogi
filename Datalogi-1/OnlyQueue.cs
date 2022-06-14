using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class OnlyQueue<T>:ISimpleQueue<T>
	{
		private MyNode<T>? First = null;
		private MyNode<T>? Last = null;

		public void AddLast(T value)
		{
			var oldLast = Last;
			Last = new MyNode<T>();
			Last.Data = value;
			if (First == null)
				First = Last;
			if(oldLast != null)
				Last.Next = oldLast;
		}

		public T GetFirst()
		{
			if (First == null)
				throw new Exception("Kön är tom");
			return First.Data;
		}

		public void RemoveFirst()
		{
			var node = Last;
			if (node == null)
				throw new Exception("Kön är tom");

			// hitta näst första noden
			while(node.Next != First)
			{
				node = node.Next;
			}
			node.Next = null;
			First=node;

		}
	}
}
