using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MillTest
{
    [TestClass]
    public class MillModelTests
    {
        MillModel testObject;

        public MillModelTests()
        {
            testObject = new MillModel();
        }

        [TestMethod]
        public void CreateMillModel()
        {
            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void CheckMillModelFields()
        {
            Assert.AreEqual(testObject.CurrentPlayer, 0);
            Assert.IsNotNull(testObject.Players[0]);
            Assert.IsNotNull(testObject.Players[1]);
            Assert.IsTrue(CheckMillModelGameTable(testObject.GameTable));
        }

        [TestMethod]
        public bool CheckMillModelGameTable( Field[,] gameTable)
        {
            if (gameTable[0, 0] != Field.Empty)
                return false;
            if (gameTable[0, 3] != Field.Empty)
                return false;
            if (gameTable[0, 6] != Field.Empty)
                return false;
            if (gameTable[1, 1] != Field.Empty)
                return false;
            if (gameTable[1, 3] != Field.Empty)
                return false;
            if (gameTable[1, 5] != Field.Empty)
                return false;
            if (gameTable[2, 2] != Field.Empty)
                return false;
            if (gameTable[2, 3] != Field.Empty)
                return false;
            if (gameTable[2, 4] != Field.Empty)
                return false;
            if (gameTable[3, 0] != Field.Empty)
                return false;
            if (gameTable[3, 1] != Field.Empty)
                return false;
            if (gameTable[3, 2] != Field.Empty)
                return false;
            if (gameTable[3, 4] != Field.Empty)
                return false;
            if (gameTable[3, 5] != Field.Empty)
                return false;
            if (gameTable[3, 6] != Field.Empty)
                return false;
            if (gameTable[4, 2] != Field.Empty)
                return false;
            if (gameTable[4, 3] != Field.Empty)
                return false;
            if (gameTable[4, 4] != Field.Empty)
                return false;
            if (gameTable[5, 1] != Field.Empty)
                return false;
            if (gameTable[5, 3] != Field.Empty)
                return false;
            if (gameTable[5, 5] != Field.Empty)
                return false;
            if (gameTable[6, 0] != Field.Empty)
                return false;
            if (gameTable[6, 3] != Field.Empty)
                return false;
            if (gameTable[6, 6] != Field.Empty)
                return false;
            return true;
        }

        [TestMethod]
        public void PlaceTokenTest1()
        {
            Assert.IsTrue(testObject.PlaceToken(0, 0));
            Assert.AreEqual(testObject.GameTable[0, 0], Field.Player1);
        }

        [TestMethod]
        public void PlaceTokenTest2()
        {
            Assert.IsTrue(testObject.PlaceToken(0, 0));
            Assert.IsTrue(testObject.GameTable[0, 0] == Field.Player1);
            Assert.IsFalse(testObject.PlaceToken(0, 0));
        }

        [TestMethod]
        public void IsInMillTest1()
        {
            testObject.GameTable[0, 0] = Field.Player1;
            testObject.GameTable[0, 3] = Field.Player1;
            testObject.GameTable[0, 6] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(0, 0));
            Assert.IsTrue(testObject.IsInMill(0, 3));
            Assert.IsTrue(testObject.IsInMill(0, 6));
        }

        [TestMethod]
        public void IsInMillTest2()
        {
            testObject.GameTable[6, 3] = Field.Player2;
            testObject.GameTable[6, 6] = Field.Player2;
            Assert.IsFalse(testObject.IsInMill(6, 3));
            Assert.IsFalse(testObject.IsInMill(6, 6));
            Assert.IsFalse(testObject.IsInMill(6, 0));
        }

        [TestMethod]
        public void IsInMillTest3()
        {
            testObject.GameTable[1, 1] = Field.Player1;
            testObject.GameTable[1, 3] = Field.Player1;
            testObject.GameTable[1, 5] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(1, 1));
            Assert.IsTrue(testObject.IsInMill(1, 3));
            Assert.IsTrue(testObject.IsInMill(1, 5));
        }

        [TestMethod]
        public void IsInMillTest4()
        {
            testObject.GameTable[3, 0] = Field.Player1;
            testObject.GameTable[3, 1] = Field.Player1;
            testObject.GameTable[3, 2] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(3, 0));
            Assert.IsTrue(testObject.IsInMill(3, 1));
            Assert.IsTrue(testObject.IsInMill(3, 2));
            Assert.IsFalse(testObject.IsInMill(3, 4));
            Assert.IsFalse(testObject.IsInMill(3, 5));
            Assert.IsFalse(testObject.IsInMill(3, 6));
        }

        [TestMethod]
        public void IsInMillTest5()
        {
            testObject.GameTable[3, 4] = Field.Player1;
            testObject.GameTable[3, 5] = Field.Player1;
            testObject.GameTable[3, 6] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(3, 4));
            Assert.IsTrue(testObject.IsInMill(3, 5));
            Assert.IsTrue(testObject.IsInMill(3, 6));
            Assert.IsFalse(testObject.IsInMill(3, 0));
            Assert.IsFalse(testObject.IsInMill(3, 1));
            Assert.IsFalse(testObject.IsInMill(3, 2));
        }

        [TestMethod]
        public void IsInMillTest6()
        {
            testObject.GameTable[0, 0] = Field.Player1;
            testObject.GameTable[3, 0] = Field.Player1;
            testObject.GameTable[6, 0] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(0, 0));
            Assert.IsTrue(testObject.IsInMill(3, 0));
            Assert.IsTrue(testObject.IsInMill(6, 0));
        }

        [TestMethod]
        public void IsInMillTest7()
        {
            testObject.GameTable[1, 1] = Field.Player1;
            testObject.GameTable[3, 1] = Field.Player1;
            testObject.GameTable[5, 1] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(1, 1));
            Assert.IsTrue(testObject.IsInMill(3, 1));
            Assert.IsTrue(testObject.IsInMill(5, 1));
        }

        [TestMethod]
        public void IsInMillTest8()
        {
            testObject.GameTable[0, 3] = Field.Player1;
            testObject.GameTable[1, 3] = Field.Player1;
            testObject.GameTable[2, 3] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(0, 3));
            Assert.IsTrue(testObject.IsInMill(1, 3));
            Assert.IsTrue(testObject.IsInMill(2, 3));
            Assert.IsFalse(testObject.IsInMill(4, 3));
            Assert.IsFalse(testObject.IsInMill(5, 3));
            Assert.IsFalse(testObject.IsInMill(6, 3));
        }

        [TestMethod]
        public void IsInMillTest9()
        {
            testObject.GameTable[4, 3] = Field.Player1;
            testObject.GameTable[5, 3] = Field.Player1;
            testObject.GameTable[6, 3] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(4, 3));
            Assert.IsTrue(testObject.IsInMill(5, 3));
            Assert.IsTrue(testObject.IsInMill(6, 3));
            Assert.IsFalse(testObject.IsInMill(0, 3));
            Assert.IsFalse(testObject.IsInMill(1, 3));
            Assert.IsFalse(testObject.IsInMill(2, 3));
        }

        [TestMethod]
        public void IsInMillTest10()
        {
            testObject.GameTable[2, 2] = Field.Player1;
            testObject.GameTable[2, 3] = Field.Player1;
            testObject.GameTable[2, 4] = Field.Player1;
            Assert.IsTrue(testObject.IsInMill(2, 2));
            Assert.IsTrue(testObject.IsInMill(2, 3));
            Assert.IsTrue(testObject.IsInMill(2, 4));
        }

        [TestMethod]
        public void RemoveTokenTest1()
        {
            Assert.IsFalse(testObject.RemoveToken(0, 0));
        }

        [TestMethod]
        public void RemoveTokenTest2()
        {
            testObject.GameTable[0, 0] = Field.Player2;
            Assert.IsTrue(testObject.RemoveToken(0, 0));
        }

        [TestMethod]
        public void RemoveTokenTest3()
        {
            testObject.GameTable[0, 0] = Field.Player2;
            testObject.GameTable[0, 3] = Field.Player2;
            testObject.GameTable[0, 6] = Field.Player2;
            Assert.IsTrue(testObject.RemoveToken(0, 0));
        }

        [TestMethod]
        public void IsAllTokenInMillTest()
        {
            testObject.GameTable[0, 0] = Field.Player2;
            testObject.GameTable[0, 3] = Field.Player2;
            testObject.GameTable[0, 6] = Field.Player2;
            Assert.IsTrue(testObject.IsAllTokenInMill(1));
            testObject.GameTable[6, 3] = Field.Player2;
            Assert.IsFalse(testObject.IsAllTokenInMill(1));
        }

        [TestMethod]
        public void JumpTokenTest()
        {
            testObject.Players[0].LostTokens = 6;
            testObject.Players[0].OnTableTokens = 3;
            Assert.IsFalse(testObject.JumpToken(0, 0, 0, 3));
            testObject.GameTable[0, 0] = Field.Player1;
            Assert.IsFalse(testObject.JumpToken(0, 0, 0, 1));
            Assert.IsTrue(testObject.JumpToken(0, 0, 4, 2));
            Assert.AreEqual(testObject.GameTable[4, 2], Field.Player1);
        }

        [TestMethod]
        public void MoveTokenTest1()
        {
            testObject.Players[0].OnTableTokens = 9;
            Assert.IsFalse(testObject.MoveToken(0, 0, 0, 3));
            testObject.GameTable[0, 0] = Field.Player1;
            Assert.IsFalse(testObject.MoveToken(0, 0, 0, 6));
            Assert.IsFalse(testObject.MoveToken(0, 0, 1, 1));
            Assert.IsTrue(testObject.MoveToken(0, 0, 0, 3));
            Assert.AreEqual(testObject.GameTable[0, 0], Field.Empty);
            Assert.AreEqual(testObject.GameTable[0, 3], Field.Player1);
            Assert.IsTrue(testObject.MoveToken(0, 3, 1, 3));
            Assert.AreEqual(testObject.GameTable[0, 3], Field.Empty);
            Assert.AreEqual(testObject.GameTable[1, 3], Field.Player1);
            Assert.IsTrue(testObject.MoveToken(1, 3, 0, 3));
            Assert.AreEqual(testObject.GameTable[1, 3], Field.Empty);
            Assert.AreEqual(testObject.GameTable[0, 3], Field.Player1);
            Assert.IsTrue(testObject.MoveToken(0, 3, 0, 0));
            Assert.AreEqual(testObject.GameTable[0, 3], Field.Empty);
            Assert.AreEqual(testObject.GameTable[0, 0], Field.Player1);
        }
    }

    [TestClass]
    public class PlayerTests
    {
        Player testObject;

        public PlayerTests()
        {
            testObject = new Player();
        }

        [TestMethod]
        public void CreatePlayer()
        {
            Assert.IsNotNull(testObject);
        }

        [TestMethod]
        public void CheckPlayerFields()
        {
            Assert.AreEqual(testObject.AllTokens, 9);
            Assert.AreEqual(testObject.LostTokens, 0);
            Assert.AreEqual(testObject.OnTableTokens, 0);
        }
    }
}
