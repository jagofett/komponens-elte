using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.Model;
using TicTacToe.ViewModel;

namespace TicTacToeLibrary.ViewModel
{
    public class Testing
    {
        private void assert(bool expr)
        {
            if (!expr)
            {
                throw new System.Exception("Testing assertion failed");
            }
        }
        public Testing()
        {
            Logic m = new Logic();
            TicTacToeViewModel vm = new TicTacToeViewModel(m);

            vm.RunTests();

        }
    }
}
