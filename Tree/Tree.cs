using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class Tree<T>
    {
        public T Data { get; set; }
        public Tree<T>? Parent { get; private set; }
        public List<Tree<T>> Children { get; private set; }

        public Tree(T data, Tree<T>? parent)
        {
            Data = data;
            Parent = parent;
            Children = new();
        }

        public void TraverseTree(Action<T> action)
        {
            action(Data);
            foreach(Tree<T> t in Children)
                t.TraverseTree(action);
        }

        public Tree<T>? DFS(T value)
        {
            if(EqualityComparer<T>.Default.Equals(Data, value))
                return this;
            
            foreach(Tree<T>? t in Children)
            {
                Tree<T>? tree = t.DFS(value);
                if(tree != null)
                    return tree;
            }

            return null;
        }

        public Tree<T>? BFS(T value)
        {
            Queue<Tree<T>> queue = new();

            queue.Enqueue(this);

            while(queue.Count > 0)
            {
                Tree<T>? tree = queue.Dequeue();

                if(EqualityComparer<T>.Default.Equals(tree.Data, value))
                    return tree;

                foreach(Tree<T> t in tree.Children)
                    queue.Enqueue(t);
            }

            return null;
        }
        public void AddTree(T data) => Children.Add(new Tree<T>(data, this));
    }
}