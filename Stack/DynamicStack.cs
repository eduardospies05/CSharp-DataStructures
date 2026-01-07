using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Node;

namespace DataStructures.Stack
{
    public class DynamicStack<T>
    {
        private Node<T>? Head;
        public int Count { get; set; }

        public void Push(T data)
        {
            Node<T> node = new(data);

            Count++;

            node.Next = Head;

            Head = node;
        }

        public T? Pop()
        {
            Node<T>? node;

            if(Count == 0)
                throw new Exception("Empty stack");

            node = Head;
            Head = Head.Next;

            Count--;

            return node.Data;
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
        }
    }
}