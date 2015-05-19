
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
using TicTacToeLibrary.Model;

namespace TicTacToe
{
    public class Start : IGame
    {
        private TicTacToeViewModel _viewModel;
        private Logic _model;
        private MainWindow _view;
        private string Player;
        private IAi _ai;

        public void StartGame(IAi aiModule)
		{
            _ai = aiModule;
			//use the aiModule to calculate the computer movements.
			_model = new Logic();

            // nézemodell létrehozása
            _viewModel = new TicTacToeViewModel(_model);
            _viewModel.GameEnded += GameEnded;
            _viewModel.CpuStep += CpuStep;

            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();

            Testing test = new Testing();
            UnitTesting unitTest = new UnitTesting();
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

        private void CpuStep(object sender, EventArgs e)
        {
            var state = _ai.doAlphaBeta(this);
            _model.NextCpuStep((State)state);
        }

        public void QuitGame()
        {
            _view.Close();
        }

	    public List<object> GetNextStates(object actState)
	    {
            return _model == null ? null : _model.GetNextStates(actState as State);
	    }

	    public object GetState()
	    {
            return _model == null ? null : _model.GetState();
	    }

	    public int Evaluate(object state)
	    {
            return (int)(_model == null ? int.MinValue : _model.Evaluate(state as State));
	    }
    }
}
