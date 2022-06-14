using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
	public interface IIndexable<T>
	{
		public int Length { get; set; }
		public T GetAt(int index);
		public void SetAt(int index, T value);
		public void RemoveAt(int index);
	}
}
