using Grundy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ai
{
    public class AI
    {

        public int doMinimax(IGameModel game)
        {
            GameTree<IState> tree = makeGameTree(game.GetState(), game);
            return minimax (tree, tree.getDepth(), true);
        }

        public int doAlphabeta(IGameModel game)
        {
            GameTree<IState> tree = makeGameTree(game.GetState(), game);
            return alphaBeta(tree, tree.getDepth(), -1000, 1000, true);
        }

        private GameTree<IState> makeGameTree(IState actState, IGameModel game)
        {

            GameTree<IState> gt = new GameTree<IState>(actState);

            List<IState> nextStates = new List<IState>();
            nextStates.AddRange(game.GetNextStates());
            foreach (IState tmp in nextStates)
            {
                gt.AddChild(tmp);
            }

            return gt;
        }


        private int minimax(GameTree<IState> node, int depth, bool maximizingPlayer)
        {

            if (depth == 0/*|| node is terminal*/)
            {

                return null;// new IGameModel().Evaluate(node.getData());
            }
            if (maximizingPlayer)
            {
                int bestValue = -1000;
                foreach (GameTree<IState> item in node)
                {

                    int val = minimax(item, depth - 1, false);
                    bestValue = Math.Max(bestValue, val);

                }
                return bestValue;
            }
            else
            {
                int bestValue = 1000;
                foreach (GameTree<IState> item in node)
                {
                    int val = minimax(item, depth - 1, true);
                    bestValue = Math.Min(bestValue, val);

                }
                return bestValue;
            }
        }

        private int alphaBeta(GameTree<IState> node, int depth, int alpha, int beta, bool maximizingPlayer)
        {
            if (depth == 0 /*|| node is terminal*/)
            {
                return null;//new Logic().Evaluate(node.getData());
            }
            if (maximizingPlayer)
            {
                int v = -1000;
                foreach (GameTree<IState> child in node)
                {
                    v = Math.Max(v, alphaBeta(child, depth - 1, alpha, beta, false));
                    alpha = Math.Max(alpha, v);
                    if (beta < alpha) break;
                }
                return v;
            }
            else
            {
                int v = 1000;
                foreach (GameTree<IState> child in node)
                {
                    v = Math.Min(v, alphaBeta(child, depth - 1, alpha, beta, true));
                    beta = Math.Min(beta, v);
                    if (beta <= alpha) break;
                }
                return v;
            }

        }
    }
}