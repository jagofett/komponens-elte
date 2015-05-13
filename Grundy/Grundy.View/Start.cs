using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FrameWork.Model;
using Grundy.Library.Model;
using Grundy.Library.ViewModel;

namespace Grundy.View
{
    public class Start :IGame
    {
        private GameLogic _model;
        private MainWindow _view;
        private GrundyViewModel _viewModel;
        private IAi _ai;
        public void StartGame(IAi aiModule)
        {
            _ai = aiModule;
            _model = new GameLogic();
            _model.GameEnd += ModelGameEnd;
            _model.CpuTurn += ModelCpuTurn;
            _view = new MainWindow();
            _viewModel = new GrundyViewModel(_model);
            _view.DataContext = _viewModel;
            _view.Show();
        }

        private void ModelCpuTurn(object sender, EventArgs eventArgs)
        {
            _model.Step(_ai.doAlphaBeta(this) as State);
        }

        private void ModelGameEnd(object sender, GrundyWinEvenetArgs grundyWinEvenetArgs)
        {
            MessageBox.Show("Játék vége, a nyertes: " + grundyWinEvenetArgs.WinnerPlayer.Name, "Játék vége!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void quitGame()
        {
            throw new NotImplementedException();
        }
    }
}
