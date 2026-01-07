using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Node;

namespace DataStructures.Queue
{
    public class MyQueue<T>
    {
        private Node<T>? Front, Back;
        public int Count { get; private set; }
        public void Enqueue(T data)
        {
            Node<T> node = new(data);

            Count++;

            if(Front == null)
            {
                Front = node;
                Back = node;
                return;
            }

            Back.Next = node;
            Back = node;
        }

        public T? Dequeue()
        {            
            T? data;

            if(Front == null)
                return default;

            data = Front.Data;

            Front = Front.Next;
            Count--;

            if(Front == null)
                Back = null;

            return data;
        }

        public T? PeekFront()
        {
            if(Front == null)
                return default;
            return Front.Data;
        }

        public T? PeekBack()
        {
            if(Back == null)
                return default;
            return Back.Data;
        }
    }
}