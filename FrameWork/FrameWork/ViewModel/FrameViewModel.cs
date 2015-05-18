using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Model;

namespace FrameWork.ViewModel
{
    class FrameViewModel : ViewModelBase
    {
        FrameModel _model;
        public DelegateCommand ButtonCommand { get; private set; }

        public ObservableCollection<GameButton> Games { get; private set; }

        public FrameViewModel()
        {
            _model = new FrameModel();
            Games = new ObservableCollection<GameButton>();
            _model.GameAdded += new EventHandler<GameAddedEventArgs>(model_gameAdded);
            _model.init();
        }

        private void model_gameAdded(object sender, GameAddedEventArgs e)
        {
            Games.Add(new GameButton
            {
                Content = e.Name,
                Started = false,
                Index = e.Index,
                ButtonCommand = new DelegateCommand(button => ButtonClick(button as GameButton))
            });
            OnPropertyChanged("Games");
        }

        private void ButtonClick(GameButton gameButton)
        {
            if (gameButton.Started)
            {
                _model.endGame(gameButton.Index);
                gameButton.Started = false;
            }
            else
            {
                _model.startGame(gameButton.Index);
                gameButton.Started = true;
            }
            OnPropertyChanged("Games");
        }

    }
}
