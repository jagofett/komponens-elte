
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interfaces;
using TicTacToe.Model;
using TicTacToe.ViewModel;
using TicTacToeLibrary.ViewModel;

namespace TicTacToe
{
    public class Start : IGame
    {
        private TicTacToeViewModel _viewModel;
        private Logic _model;
        private MainWindow _view;
        private string Player;

        public void StartGame(IAi aiModule)
		{
			//use the aiModule to calculate the computer movements. (probably inject to logic!)
			_model = new Logic();

            // nézemodell létrehozása
            _viewModel = new TicTacToeViewModel(_model);
            _viewModel.GameEnded += GameEnded;

            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();

            Testing test = new Testing();
        }

        private void GameEnded(object sender, TicTacToeViewModel.WinEventArgs e)
        {
            Player = e.Player;
            if (MessageBox.Show("Game over! " + e.Player + " wins! Would you like to play again?", "TicTacToe", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                _view.Close();
            }
            else
            {
                _viewModel.NewGame();
            }
        }

        public void QuitGame()
        {
            _view.Close();
        }

	    public List<object> GetNextStates(object actState)
	    {
		    throw new NotImplementedException();
	    }

	    public object GetState()
	    {
		    throw new NotImplementedException();
	    }

	    public int Evaluate(object state)
	    {
		    throw new NotImplementedException();
	    }
    }
}
