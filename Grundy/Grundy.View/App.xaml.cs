using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grundy.Library.Model;
using Grundy.Library.ViewModel;

namespace Grundy.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private GameLogic _model;
        private MainWindow _view;
        private GrundyViewModel _viewModel;
        public App()
        {
            Startup += new StartupEventHandler(AppStartup);
        }

        private void AppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            //only for debug, for release, framework will use the start.cs StartGame method!!!
            _model = new GameLogic();
            _model.GameEnd += ModelGameEnd;
            _view = new MainWindow();
            _viewModel = new GrundyViewModel(_model);
            _view.DataContext = _viewModel;
            _view.Show();
        }
        private void ModelGameEnd(object sender, GrundyWinEvenetArgs grundyWinEvenetArgs)
        {
            MessageBox.Show("Játék vége, a nyertes: " + grundyWinEvenetArgs.WinnerPlayer.Name, "Játék vége!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
