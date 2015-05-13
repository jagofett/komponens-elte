using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace ai
{
    interface IAI
    {
        int doMinimax(IGame game);
        int doAlphaBeta(IGame game);
    }
}

