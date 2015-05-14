using System;
using Grundy.Library.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grundy.Test
{
    [TestClass]
    public class GrundyModelTest
    {
        private Library.Model.GameLogic _testLogic;


        
        public  GrundyModelTest()
        {
            _testLogic = new GameLogic();
        }
    }
}
