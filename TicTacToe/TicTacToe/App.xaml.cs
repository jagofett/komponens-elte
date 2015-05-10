using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Model;
using TicTacToe.ViewModel;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TicTacToeViewModel _viewModel;
        private Logic _model;
        private MainWindow _view;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
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
            String jatekos = e.Player ? "O játékos" : "X játékos";
            if (MessageBox.Show("Vége a játéknak! " + jatekos + " nyert! Szeretnél újra játszani?", "Amőba", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                Application.Current.Shutdown();
            }
            else
            {
                _viewModel.NewGame();
            }
        }
    }
}
