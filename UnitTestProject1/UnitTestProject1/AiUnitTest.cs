using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using TicTacToe.Model;
using ai;


namespace UnitTestProject1
{
    [TestClass]
    public class AiUnitTest
    {
        [TestMethod]
        public void Minimax_Test(IGame game)
        {
            State testState = new State(3);
            testState.SetTableValue(0, 0, 0);
            testState.SetTableValue(0, 1, 1);

            Ai ai = new Ai();
            ai.makeGameTree()

        }

        [TestMethod]
        public void AlphaBeta_Test(IGame game)
        {

        }
    }
}
