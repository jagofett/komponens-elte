using MillTest;
using MillTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Interfaces;

namespace Mill
{
    public class Start :IGame
    {
        private MillViewModel _viewModel;
        private MillModel _model;
        private MainWindow _view;
        private IAi _ai;

        public void StartGame(IAi aiModule)
        {
            _ai = aiModule;
            //use the aiModule to calculate the computer movements. (probably inject to logic!)
            _model = new MillModel();

            // nézemodell létrehozása
            _viewModel = new MillViewModel(_model);
            //_viewModel.GameEnded += GameEnded;

            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }

        public void QuitGame()
        {
            _view.Close();
        }

        public object GetState()
        {
            return new object();
        }

        public int Evaluate(object state)
        {
            throw new NotImplementedException();
        }

        public List<object> GetNextStates(object actState)
        {
            throw new NotImplementedException();
        }
    }
}
