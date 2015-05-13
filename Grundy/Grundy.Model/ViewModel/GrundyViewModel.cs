using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Grundy.Library.Model;

namespace Grundy.Library.ViewModel
{
    public class GrundyViewModel : ViewModelBase
    {
        private GameLogic _gameLogic;
        private ObservableCollection<GrundyElement> _Elements;

        public DelegateCommand NewGame { get; set; }

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

        public int GameType { get; set; }

        private int _mainSize;

        public int Size
        {
            get { return _mainSize; }
            set
            {
                _mainSize = IsStarted ? _mainSize : value;
                OnPropertyChanged("Size");
            }
        }

        public int PileCount { get { return _gameLogic == null ? 0 : _gameLogic.ActPileCount; } }

        private string _info;

        public string Info
        {
            get { return _info; }
            set { _info = value; OnPropertyChanged("Info"); }
        }

        private Player _actPlayer;

        public Player ActPlayer
        {
            get { return _actPlayer; }
            private set
            {
                _actPlayer = value;
                OnPropertyChanged("ActPlayer");
            }
        }

        public bool IsStarted
        {
            get { return _gameLogic != null && _gameLogic.IsStarted; }
        }

        public bool ButtonEnabled
        {
            get { return !IsStarted; }
        }

        public EventHandler<GrundyWinEvenetArgs>  GameEndEvent { get; set; }
        private void OnGameEnd(Player winner)
        {
            if (GameEndEvent != null)
            {
                GameEndEvent(this, new GrundyWinEvenetArgs(winner));
            }
        }
        #region Constructors

        public GrundyViewModel(GameLogic logic)
        {
            _gameLogic = logic;
            _gameLogic.GameStart += GameStart;
            _gameLogic.GameEnd += GameEnd;
            _gameLogic.PlayerChange += PlayerChange;

            //delegate commands 
            NewGame = new DelegateCommand(StartGameEx);

            Size = 7; //default size
        }

        private void StartGameEx(object o)
        {
            var type = (GameType)GameType;
            if (Size >= 7 && Size <=50 && !IsStarted)
            {
                _gameLogic.Start(Size, type);
                OnPropertyChanged("ButtonEnabled");
            }
        }

        #endregion


        #region Event handlers
        private void GameStart(object sender, EventArgs eventArgs)
        {
            
            Size = _gameLogic.GetState().MainSize;
            FieldUpdate();
            ActPlayer = _gameLogic.ActPlayer;
            Info = ActPlayer.Name + " következik!";

            OnPropertyChanged("PileCount");
        }

        private void FieldUpdate()
        {
            if (Elements != null)
            {
                _Elements.Clear();
                OnPropertyChanged("Elements");
            }
            OnPropertyChanged("PileCount");
            Elements = new ObservableCollection<GrundyElement>();
            var id = 0;
            for (int i = 0; i < _gameLogic.ActPileCount; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Elements.Add(new GrundyElement
                    {
                        X =i,
                        Id = id,
                        Y = j,
                        StepCommand = new DelegateCommand(p => StepCommand(Convert.ToInt32(p))),
                        IsEnabled = j < _gameLogic[i].Size
                    });
                    id++;
                }
            }
        }

        private void StepCommand(int id)
        {
            if (!IsStarted) return;
            var elem = Elements[id];
            if (!_gameLogic.Step(elem.X, elem.Y + 1))
            {
                Info = " Hibás lépés!";
            }

        }

        private void GameEnd(object sender, GrundyWinEvenetArgs eventArgs)
        {
            FieldUpdate();
            Info = "Játék vége, a nyertes: " + eventArgs.WinnerPlayer.Name;
            OnPropertyChanged("ButtonEnabled");
            OnGameEnd(eventArgs.WinnerPlayer);
        }
        private async void PlayerChange(object sender, EventArgs eventArgs)
        {
            ActPlayer = _gameLogic.ActPlayer;
            if (ActPlayer.PlayerType == PlayerType.ComputerPlayer)
            {
                //sleep to view cpu-s
            }

                FieldUpdate();                
           
            Info = ActPlayer.Name + "következik!";

        }

        #endregion

    }
}
