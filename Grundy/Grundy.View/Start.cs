using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Grundy.Library.Model;
using Grundy.Library.ViewModel;
using Interfaces;

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
            _model.CpuTurn += ModelCpuTurn;
            _view = new MainWindow();
            _viewModel = new GrundyViewModel(_model);
            _viewModel.GameEndEvent += ModelGameEnd;
            _view.DataContext = _viewModel;
            _view.Closing += _view_Closing;

            _view.Show();
        }

        void _view_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        public void QuitGame()
        {
            _view.Close();
        }

        public List<object> GetNextStates(object actState)
        {
            return _model == null ? null :  _model.GetNextStates(actState as State);
        }

        public Object GetState()
        {
            return _model == null ? null : _model.GetState();
        }

        public int Evaluate(object state)
        {
            return (int) (_model == null ? int.MinValue : _model.Evaluate(state as State));
        }
        private void ModelCpuTurn(object sender, EventArgs eventArgs)
        {
            State step;
            if (_ai == null)
            {
                step = GetNextStates(GetState()).First() as State;
            }
            else
            {
                step = _ai.doAlphaBeta(this) as State;
            }
            _model.Step(step);
        }

        private void ModelGameEnd(object sender, GrundyWinEvenetArgs grundyWinEvenetArgs)
        {
            MessageBox.Show("Játék vége, a nyertes: " + grundyWinEvenetArgs.WinnerPlayer.Name, "Játék vége!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

    }
}
