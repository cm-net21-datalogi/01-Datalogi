namespace Datalogi_1
{
	// En queue är LIFO (last in, first out)
	// Vi lägger till element LAST och tar bort FIRST
	public interface ISimpleQueue<T>
	{
		// du behöver både referenser till Last och First
		public void AddLast(T value);
		public T GetFirst();
		public void RemoveFirst();
	}

}
