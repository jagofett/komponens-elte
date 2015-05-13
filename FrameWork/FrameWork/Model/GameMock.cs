using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrameWork.Model
{
    class GameMock : IGame
    {
        Window window;

        public void newGame()
        {
            window = new Window();
            window.Show();
        }

        public void quitGame()
        {
            window.Close();
        }
    }
}
