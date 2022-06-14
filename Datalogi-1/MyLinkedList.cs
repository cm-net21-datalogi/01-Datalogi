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
        public MyNode<T>? Current = null;

        public void Next() {
            Current = Current.Next;
        }
        public void Reset()
        {
            Current = Head;
        }

        public void Push(T value) {
            MyNode<T> oldHead = Head;
            this.Head = new MyNode<T>();
            this.Head.Data = value;
            this.Head.Next = oldHead;
            if(Current == null)
            {
                Current = Head;
            }
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

}
