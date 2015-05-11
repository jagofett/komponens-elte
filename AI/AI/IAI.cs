using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grundy.Interface;

namespace ai
{
    interface IAI
    {
        int doMinimax(IGameModel game);
        int doAlphaBeta(IGameModel game);
    }
}

