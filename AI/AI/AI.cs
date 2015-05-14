using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;


namespace ai
{
    public class Ai : IAi
    {

        public Ai()
        {

        }
        public Object doMinimax(IGame game)
        {
            GameTree<Object> gt = new GameTree<Object>(game.GetState());
            GameTree<Object> tree = makeGameTree(gt, game);
            return minimax(tree, 4, true, game);
        }

        public Object doAlphaBeta(IGame game)
        {
            GameTree<Object> gt = new GameTree<Object>(game.GetState());
            GameTree<Object> tree = makeGameTree(gt, game);
            return alphaBeta(tree,4, -1000, 1000, true, game);
        }

        public GameTree<Object> makeGameTree(GameTree<Object> gt, IGame game)
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


        private Object minimax(GameTree<Object> node, int depth, bool maximizingPlayer, IGame game)
        {

            if (depth == 0|| node.IsTerminal())
            {

                return node.getData();
            }
            if (maximizingPlayer)
            {
                int bestValue = -10000;
                Object bestState = (Object)new Object();
                foreach (GameTree<Object> item in node)
                {

                    Object val = minimax(item, depth - 1, false, game);
                    //bestValue = Math.Max(bestValue, game.Evaluate(val));
                    int tmp = game.Evaluate(val);
                    if (bestValue < tmp)
                    {
                        bestValue = tmp;
                        bestState = item.getData();
                    }


                }
                return bestState;
            }
            else
            {
                int bestValue = 10000;
                Object bestState = (Object)new Object();
                foreach (GameTree<Object> item in node)
                {
                    Object val = minimax(item, depth - 1, true, game);
                    //bestValue = Math.Min(bestValue, val);
                    int tmp = game.Evaluate(val);
                    if (bestValue > tmp)
                    {
                        bestValue = tmp;
                        bestState = item.getData();
                    }

                }
                return bestState;
            }
        }

        private Object alphaBeta(GameTree<Object> node, int depth, int alpha, int beta, bool maximizingPlayer, IGame game)
        {
            if (depth == 0 || node.IsTerminal())
            {
                return node.getData();
            }
            if (maximizingPlayer)
            {
                int v = -10000;
                Object bestState = (Object)new Object();
                foreach (GameTree<Object> child in node)
                {
                    Object tmp = alphaBeta(child, depth - 1, alpha, beta, false, game);
                    //v = Math.Max(game.Evaluate(bestState), game.Evaluate(tmp));
                    int t = game.Evaluate(tmp);
                    if (v < t)
                    {
                        v = t;
                        bestState = tmp;
                    }
                    //alpha = Math.Max(alpha, v);
                    if (alpha < v)
                    {
                        alpha = v;
                        bestState = tmp;
                    }
                    if (beta < alpha) break;
                }
                return bestState;
            }
            else
            {
                int v = 1000;
                Object bestState = (Object)new Object();
                foreach (GameTree<Object> child in node)
                {
                    Object tmp = alphaBeta(child, depth - 1, alpha, beta, false, game);
                    int t = game.Evaluate(tmp);
                    //v = Math.Min(v, alphaBeta(child, depth - 1, alpha, beta, true, game));
                    if (v > t)
                    {
                        v = t;
                        bestState = tmp;
                    }
                    //beta = Math.Min(beta, v);
                    if (beta > v)
                    {
                        beta = v;
                        bestState = tmp;
                    }
                    if (beta <= alpha) break;
                }
                return bestState;
            }

        }
    }
}
