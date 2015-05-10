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
        //public int Id { get; private set; }

        public Pile(int size) 
        {
            Size = size;
        }


        public bool CanDivide()
        {
            return Size > 2;
        }

        public void Take(int amount)
        {
            Size -= amount;
        }
    }
}
