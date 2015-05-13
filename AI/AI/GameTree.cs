using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai
{
    delegate void TreeVisitor<T>(T nodeData);

    class GameTree<T> : IEnumerable
    {
        private T data;
        private LinkedList<GameTree<T>> children;
        private int depth;

        public GameTree(T data)
        {
            this.data = data;
            children = new LinkedList<GameTree<T>>();
            //depth = 1;
        }

        public void AddChild(T data)
        {
            children.AddFirst(new GameTree<T>(data));
           // depth += 1;
        }

        public void AddChildren(List<T> ch){
            foreach (T t in ch)
            {
                AddChild(t);
            }
        }

        public GameTree<T> GetChild(int i)
        {
            foreach (GameTree<T> n in children)
                if (--i == 0)
                    return n;
            return null;
        }

        public LinkedList<GameTree<T>> GetChildren()
        {
            return children;
        }

        public void Traverse(GameTree<T> node, TreeVisitor<T> visitor)
        {
            visitor(node.data);
            foreach (GameTree<T> kid in node.children)
                Traverse(kid, visitor);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (GameTree<T> child in children)
            {
                yield return child;
            }
        }

        public T getData()
        {
            return data;
        }

        public int getDepth()
        {
            return getDepth();
        }
    }
}
