namespace Datalogi_1
{
	// Top == First
	public interface ISimpleQueue<T>
	{
		public void AddLast(T value);
		public T GetFirst();
		public void RemoveFirst();
	}

}
