using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interfaces;

namespace FrameWork.Model
{
    class GameMock : IGame
    {
        Window window;

        public void StartGame(IAi ai)
        {
            window = new Window();
            window.Show();
        }

        public void QuitGame()
        {
            window.Close();
        }

        public int Evaluate(object o) { return 0; }
        public object GetState() { return null; }
        public List<object> GetNextStates(object o) { return null; }



    }
}
