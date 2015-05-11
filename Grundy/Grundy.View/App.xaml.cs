using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grundy.Interface;
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
            _model = new GameLogic();
            _view = new MainWindow();
            _viewModel = new GrundyViewModel(_model);
            _view.DataContext = _viewModel;
            _view.Show();
        }


        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void QuitGame()
        {
            throw new NotImplementedException();
        }

        public ICollection GetNextStates()
        {
            throw new NotImplementedException();
        }

        public int Evaluate(IState state)
        {
            throw new NotImplementedException();
        }
    }
}
