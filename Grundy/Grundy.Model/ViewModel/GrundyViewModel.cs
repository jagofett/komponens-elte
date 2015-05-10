using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grundy.Library.Model;

namespace Grundy.Library.ViewModel
{
    public class GrundyViewModel : ViewModelBase
    {
        private GameLogic _gameLogic;
        private ObservableCollection<GrundyElement> _Elements;
        public ObservableCollection<GrundyElement> Elements
        {
            get
            {
                return _Elements;
            }
            set
            {
                _Elements = value;
                OnPropertyChanged("Elements");
            }
        }
        public int Size { get; set; }
        public Player ActPlayer { get; private set; }

        public bool IsStarted
        {
            get { return _gameLogic != null && _gameLogic.IsStarted; }
        }



        #region Constructors

        public GrundyViewModel(GameLogic logic)
        {
            _gameLogic = logic;
            _gameLogic.GameStart += GameStart;
            _gameLogic.GameEnd += GameEnd;
            _gameLogic.PlayerChange += PlayerChange;
        }


        #endregion


        #region Event handlers
        private void GameStart(object sender, EventArgs eventArgs)
        {
            
            Size = _gameLogic.GetState().MainSize;
            ActPlayer = _gameLogic.ActPlayer;


        }
        private void GameEnd(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
        private void PlayerChange(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
