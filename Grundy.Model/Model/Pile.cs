using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy.Library.Model
{
    public class Pile
    {
        public int Size { get; private set; }
        public int Id { get; private set; }
        static int _staticId;

        public Pile(int size) 
        {
            Size = size;
            Id = ++_staticId;
        }


        public bool CanDivide()
        {
            return Size > 2 && (Size % 2 != 0);
        }

        public void Take(int amount)
        {
            Size -= amount;
        }
    }
}
