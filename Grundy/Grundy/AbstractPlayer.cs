using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    abstract class AbstractPlayer
    {
        public string name { protected set; get; }

        public abstract Tuple<int, int> playTurn(List<Pile> piles);
        protected abstract Pile choosePile(List<Pile> piles);
        protected abstract int dividePile(Pile pile);
    }
}
