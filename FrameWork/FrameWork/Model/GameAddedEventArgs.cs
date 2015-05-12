using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Model
{
    class GameAddedEventArgs
    {
        public int Index { get; set; }
        public String Name { get; set; }

        public GameAddedEventArgs(int index, String name)
        {
            Index = index;
            Name = name;
        }
    }
}