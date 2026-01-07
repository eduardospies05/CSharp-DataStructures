using System;
using DataStructures.HashTable;
using DataStructures.LinkedList;
using DataStructures.Queue;
using DataStructures.Stack;
using DataStructures.Tree;

namespace DataStructures
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.Clear();
            Test_List();
            Test_Stack();
            Test_Queue();
            Test_HashTable();
            Test_Tree();
        }

        private static void Test_List()
        {
            MyLinkedList<int> list = new();

            Console.WriteLine("Linked list implementation test...");

            for(int i = 0; i < 10; i++)
                list.Add(i);

            for(int i = 0; i < list.Count; i++)
                Console.WriteLine(list.Get(i));

            Console.WriteLine("Testing removing index 1");

            list.Remove(1);

            for(int i = 0; i < list.Count; i++)
                Console.WriteLine(list.Get(i));

            Console.WriteLine("==================================");
        }

        private static void Test_Stack()
        {
            DynamicStack<int> stack = new();

            Console.WriteLine("Dynamic stack implementation implementation test...");

            for(int i = 0; i < 10; i++)
                stack.Push(i);

            for(int i = 0; i < 10; i++)
                Console.WriteLine(stack.Pop());

            Console.WriteLine("==================================");
        }

        private static void Test_Queue()
        {
            MyQueue<int> queue = new();

            Console.WriteLine("Queue implementation implementation test...");

            for(int i = 0; i < 10; i++)
                queue.Enqueue(i);

            for(int i = 0; i < 10; i++)
                Console.WriteLine(queue.Dequeue());

            Console.WriteLine("==================================");
        }

        private static void Test_HashTable()
        {
            MyHashTable<int> table = new();

            Console.WriteLine("Hash Table implementation implementation test...");

            table["Eduardo"] = 10;

            Console.WriteLine($"Key: \"Eduardo\", Value: {table["Eduardo"]}");

            Console.WriteLine("==================================");
        }

        private static void Test_Tree()
        {
            Tree<string> tree = new("Root", null);

            Console.WriteLine("Tree BFS/DFS implementation test...");

            Tree<string> A, B;
            Tree<string>? foundA, foundB;

            tree.AddTree("A");
            tree.AddTree("B");

            A = tree.Children[0];
            B = tree.Children[1];

            A.AddTree("A2");
            A.Children[0].AddTree("A3");

            B.AddTree("B2");

            foundA = tree.BFS("A3");

            if(foundA != null)
                Console.WriteLine("Found A3, BFS is working");

            foundB = tree.DFS("B2");

            if(foundB != null)
                Console.WriteLine("Found B2, DFS is working");
        }
    }
}