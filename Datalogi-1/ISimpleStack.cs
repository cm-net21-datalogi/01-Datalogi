namespace Datalogi_1
{
	// Vi behöver spara både datan och en referens till nästa nod, vi använder MyNode för det
	/*public class MyNode<T>
	{
		public T Data { get; set; }
		public MyNode<T> Next { get; set; }
	}*/

	// Dessa metoder måste vår datastruktur implementera för att få lov att kalla sig för stack
	public interface ISimpleStack<T>
	{
		public void Push(T value);  // lägg till värde överst i stacken
		public T Pop();  // ta bort översta värdet från stacken
		public T Peek();  // titta på översta värdet i stacken
	}

}
