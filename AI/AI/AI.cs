using FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ai
{
    public class AI
    {

        public int doMinimax(IGame game)
        {
            GameTree<Object> gt = new GameTree<Object>(game.GetState());
            GameTree<Object> tree = makeGameTree(gt, game);
            return minimax(tree, 4, true, game);
        }

        public int doAlphabeta(IGame game)
        {
            GameTree<Object> gt = new GameTree<Object>(game.GetState());
            GameTree<Object> tree = makeGameTree(gt, game);
            return alphaBeta(tree,4, -1000, 1000, true, game);
        }

        private GameTree<Object> makeGameTree(GameTree<Object> gt, IGame game)
        {


            List<Object> nextStates = new List<Object>();
            nextStates.AddRange(game.GetNextStates(gt.getData()));
            foreach (Object tmp in nextStates)
            {
                gt.AddChild(tmp);
            }


            foreach (GameTree<Object> x in gt)
            {
                List<Object> tmp = game.GetNextStates(x.getData());
                x.AddChildren(tmp);
                foreach(GameTree<Object> c in x){
                    tmp = game.GetNextStates(c.getData());
                    c.AddChildren(tmp);
                }
            }


            return gt;
        }


        private int minimax(GameTree<Object> node, int depth, bool maximizingPlayer, IGame game)
        {

            if (depth == 0/*|| node is terminal*/)
            {

                return game.Evaluate(node.getData());
            }
            if (maximizingPlayer)
            {
                int bestValue = -1000;
                foreach (GameTree<Object> item in node)
                {

                    int val = minimax(item, depth - 1, false, game);
                    bestValue = Math.Max(bestValue, val);

                }
                return bestValue;
            }
            else
            {
                int bestValue = 1000;
                foreach (GameTree<Object> item in node)
                {
                    int val = minimax(item, depth - 1, true, game);
                    bestValue = Math.Min(bestValue, val);

                }
                return bestValue;
            }
        }

        private int alphaBeta(GameTree<Object> node, int depth, int alpha, int beta, bool maximizingPlayer, IGame game)
        {
            if (depth == 0 /*|| node is terminal*/)
            {
                return game.Evaluate(node.getData());
            }
            if (maximizingPlayer)
            {
                int v = -1000;
                foreach (GameTree<Object> child in node)
                {
                    v = Math.Max(v, alphaBeta(child, depth - 1, alpha, beta, false, game));
                    alpha = Math.Max(alpha, v);
                    if (beta < alpha) break;
                }
                return v;
            }
            else
            {
                int v = 1000;
                foreach (GameTree<Object> child in node)
                {
                    v = Math.Min(v, alphaBeta(child, depth - 1, alpha, beta, true, game));
                    beta = Math.Min(beta, v);
                    if (beta <= alpha) break;
                }
                return v;
            }

        }
    }
}