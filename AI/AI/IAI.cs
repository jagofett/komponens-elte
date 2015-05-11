using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;

namespace ai
{
    interface IAI
    {
        int doMinimax(Logic game);
        int doAlphaBeta(GameTree<State> node, int depth, int alpha, int beta, bool maximizingPlayer);
    }
}

