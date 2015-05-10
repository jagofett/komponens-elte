using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public class TicTacToeViewModel : ViewModelBase
    {
        #region Properties

        private Logic _model;
        
        private ObservableCollection<TicTacToeElement> _Elements;
        public ObservableCollection<TicTacToeElement> Elements
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

        /// <summary>
        /// Ha hamis, akkor az első játékos jön, ha igaz, akkor a második
        /// </summary>
        private bool Player = false;

        #endregion

        #region DelegateCommands

        #endregion

        #region Events

        public class WinEventArgs : EventArgs
        {
            /// <summary>
            /// igaz, ha O játékos, hamis ha X játékos
            /// </summary>
            public bool Player { get; set; }
            public WinEventArgs(bool player)
            {
                Player = player;
            }
        }

        public event EventHandler<WinEventArgs> GameEnded;


        #endregion

        #region Constructor
        public TicTacToeViewModel(Logic model)
        {
            _model = model;
            Size = Logic.SIZE;
            CreateGameTable(Logic.SIZE);

        }

        #endregion

        #region Methods

        public void CreateGameTable(int size)
        {
            Elements = new ObservableCollection<TicTacToeElement>();
            int idCounter = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Elements.Add(new TicTacToeElement() { 
                        Text = "", 
                        X = i, 
                        Y = j, 
                        Id = idCounter,
                        IsEnabled = true,
                        StepCommand = new DelegateCommand(param => FieldChosen(Convert.ToInt32(param)))
                    });
                    idCounter++;
                }
            }
        }
        public void NewGame()
        {
            _model.NewGame();
            foreach (TicTacToeElement element in Elements)
            {
                element.Text = "";
                element.IsEnabled = true;
            }
        }

        public void FieldChosen(int id)
        {
            TicTacToeElement element = Elements[id];
            if (!element.IsEnabled)
            {
                return;
            }
            if (!Player)
            {
                element.Text = "O";
            }
            else
            {
                element.Text = "X";
            }
            Player = !Player;
            element.IsEnabled = false;

            int player = Player ? 2 : 1;
            _model.UpdateTable(element.X, element.Y, player);


            #region Evaluations on screen for testing
            
            /*foreach (TicTacToeElement _element in Elements)
            {
                if (_model.CanPlace(_element.X, _element.Y))
                {
                    _element.Text = _model.ValueTableValue(_element.X, _element.Y);
                }
            }*/
            
            #endregion


            bool end = _model.IsGameOver();
            if (end)
            {
                if (GameEnded != null)
                {
                    GameEnded(this, new WinEventArgs(Player));
                }
            }
        }

        #endregion

    }
}
