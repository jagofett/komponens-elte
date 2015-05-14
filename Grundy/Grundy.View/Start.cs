using System;
using System.Runtime;
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
			//message display event:
	        //_viewModel.InfoEvent += (sender, args) => MessageBox.Show(args.Text);

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
			var defStep = GetNextStates(GetState()).First() as State;
	        var step = defStep;
			if (_ai != null)
            {
                //step = _ai.doMinimax(this) as State;
                step = _ai.doAlphaBeta(this) as State;
            }
	        if (!_model.Step(step))
	        {
		        MessageBox.Show("Hibás AI lépés! Az első lehetséges lépés próbálása...");
				//try to step the first available step.
		        _model.Step(defStep);
	        }
        }

        private void ModelGameEnd(object sender, GrundyWinEvenetArgs grundyWinEvenetArgs)
        {
            MessageBox.Show("Játék vége, a nyertes: " + grundyWinEvenetArgs.WinnerPlayer.Name, "Játék vége!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

    }
}
