using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Model;

namespace FrameWork.ViewModel
{
    class FrameViewModel : ViewModelBase
    {
        FrameModel _model;
        public DelegateCommand TicTacToeCommand { get; private set; }
        public DelegateCommand GrundyCommand { get; private set; }
        public DelegateCommand MillCommand { get; private set; }

        public FrameViewModel()
        {
            _model = new FrameModel();
            TicTacToeCommand = new DelegateCommand(x => _model.startGame(0));
            GrundyCommand = new DelegateCommand(x => _model.startGame(1));
            MillCommand = new DelegateCommand(x => _model.startGame(2));

        }
    }
}
