using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Node
{
    public class Node<T>
    {
        public T Data { get; private set; }
        public Node<T>? Previous, Next;
        public Node(T Data)
            => this.Data = Data;
    }
}