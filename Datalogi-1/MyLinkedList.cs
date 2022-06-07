using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalogi_1
{
    public class MyLinkedList<T>
    {
        private MyNode<T>? Head = null;
        // lägg till Current
        public void Push(T value) {
            MyNode<T> oldHead = Head;
            this.Head = new MyNode<T>();
            this.Head.Data = value;
            this.Head.Next = oldHead;
        }

        public T Get(int index) {
            var nodeReference = this.Head;
            for(int i = 0; i < index; i++)
            {
                nodeReference = nodeReference.Next;
            }
            return nodeReference.Data;
        }
    }
    public class MyNode<T>
    {
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }
    }
}
