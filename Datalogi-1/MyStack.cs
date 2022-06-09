using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public class MyStack<T> : SimpleStack<T>
	{
		private MyNode<T> Top = null;


		public void Push(T value)
		{
			Top = new MyNode<T>();
			Top.Data = value;
			// TODO: vad gör vi om stacken inte är tom?
		}
		public T Peek()
		{
			// TODO: vad ska vi göra om listan är tom?
			return Top.Data;
		}

		public T Pop()
		{
			// Två möjligheter:
			// 1. stacken är tom
			// 2. stacken har minst en nod
			if(Top== null)
			{
				throw new Exception("TODO: Berätta vad som har gått fel");
			}
			else
			{
				// stacken har minst en nod
				T value = Top.Data;
				Top = Top.Next;
				return value;
			}
	}

	/*public class MyNode<T>
	{
		public T Data { get; set; }
		public MyNode<T> Next { get; set; }
	}*/

	public interface SimpleStack<T>
	{
		public void Push(T value);
		public T Pop();
		public T Peek();
	}


}
