using FrameWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Model;
using TicTacToe.ViewModel;

namespace TicTacToe
{
    public class Start : IGame
    {
        private TicTacToeViewModel _viewModel;
        private Logic _model;
        private MainWindow _view;
        private bool Player;

        public void newGame()
        {
            _model = new Logic();

            // nézemodell létrehozása
            _viewModel = new TicTacToeViewModel(_model);
            _viewModel.GameEnded += GameEnded;

            // nézet létrehozása
            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }

        private void GameEnded(object sender, TicTacToeViewModel.WinEventArgs e)
        {
            Player = e.Player;
            quitGame();
        }

        public void quitGame()
        {
            String jatekos = Player ? "O játékos" : "X játékos";
            if (MessageBox.Show("Vége a játéknak! " + jatekos + " nyert! Szeretnél újra játszani?", "Amőba", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                _view.Close();
            }
            else
            {
                _viewModel.NewGame();
            }
        }
    }
}
