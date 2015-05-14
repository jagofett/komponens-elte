using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai
{

    public class GameTree<T> : IEnumerable
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

        public bool IsTerminate()
        {
            return children.Count == 0;
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
