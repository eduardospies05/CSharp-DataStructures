using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Node;

namespace DataStructures.LinkedList
{
    public class MyLinkedList<T> // eh uma lista duplamente encadeada.
    {
        private Node<T>? Head, Tail;
        public int Count { get; set; }

        public void Add(T data)
        {
            Node<T> node = new(data);

            Count++;

            if(Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public T? Get(int index)
        {
            Node<T>? node = GetNode(index);

            if(node == null)
                return default;

            return node.Data;
        }

        public void Remove(int index)
        {
            Node<T>? node = GetNode(index);

            if(node == null)
                return;

            Count--;

            if(Head == node)
            {
                Head = Head.Next;
                Head!.Previous = null;
                return;
            }

            if(Tail == node)
            {
                Tail = Tail.Previous;
                Tail!.Next = null;
                return;
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        private Node<T>? GetNode(int index)
        {
            Node<T>? node;

            if(index < 0 || index >= Count || Head == null)
                return default;

            if(index == Count - 1)
                return Tail;

            node = Head;
                
            for(int i = 0; i < index; i++, node = node.Next);

            return node;
        }
    }
}