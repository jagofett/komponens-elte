using MillTest;
using MillTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mill
{
    public class Start
    {
        private MillViewModel _viewModel;
        private MillModel _model;
        private MainWindow _view;
        public void StartGame()
        {
            //use the aiModule to calculate the computer movements. (probably inject to logic!)
            //_model = new Logic();

            // nézemodell létrehozása
            _viewModel = new MillViewModel(_model);
            //_viewModel.GameEnded += GameEnded;

            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();

        }
    }
}
