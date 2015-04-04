using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    class Pile
    {
        public int size { get; private set; }
        public int ID { get; private set; }
        static int staticID;

        public Pile (int size)
        {
            this.size = size;
            this.ID = ++staticID;
        }

        public bool canDivide()
        {
            return size > 2;
        }

        public void take(int amount)
        {
            size -= amount;
        }
    }
}
