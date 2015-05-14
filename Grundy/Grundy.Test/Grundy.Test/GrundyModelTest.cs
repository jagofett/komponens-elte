using System;
using Grundy.Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grundy.Test
{
    [TestClass]
    public class GrundyModelTest
    {
        private Library.Model.GameLogic _testLogic;
        private int testSize;
        private GameType testType;
        
        public  GrundyModelTest()
        {
            _testLogic = new GameLogic();
        }

        [TestMethod]
        public void GameTest()
        {
            testSize = 7;
            testType = GameType.PvP;
            _testLogic.Start(testSize,testType);
           
            //main size
            Assert.AreEqual(testSize,_testLogic.GetState().MainSize);
            //first pile size
            Assert.AreEqual(1,_testLogic.GetState().Piles.Count);
            //game type
            Assert.AreEqual(testType,_testLogic.GetState().Type);
            //pile numbers
            Assert.AreEqual(1,_testLogic.ActPileCount);
            //act player type
            Assert.AreEqual(PlayerType.HumanPlayer,_testLogic.ActPlayer.PlayerType);
            
            //step one
            int stackSize = 3;
            _testLogic.Step(0,stackSize);

            Assert.AreEqual(2,_testLogic.ActPileCount);
            Assert.AreEqual(stackSize,_testLogic.GetState().Piles[0].Size);






        }


    }
}
