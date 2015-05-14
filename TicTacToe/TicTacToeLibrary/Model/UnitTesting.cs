using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Model;

namespace TicTacToeLibrary.Model
{
    public class UnitTesting
    {

       private void assert(bool expr)
       {
            if (!expr)
            {
                throw new System.Exception("Testing assertion failed");
            }
        }
        public UnitTesting()
        {
            Logic m = new Logic();
            

            m.RunTests();

        }

    }
}
