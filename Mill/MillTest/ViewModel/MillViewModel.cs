using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillTest.ViewModel
{
    public class MillViewModel : ViewModelBase
    {
        #region Properties

        private MillModel _model;

        private string _Dummy00;
        public string Dummy00
        {
            get { return _Dummy00; }
            set
            {
                _Dummy00 = value;
                OnPropertyChanged("Dummy00");
            }
        }


        private ObservableCollection<ViewElement> _Elements;
        public ObservableCollection<ViewElement> Elements
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

        #endregion

        #region DelegateCommands

        public DelegateCommand MillStepCommand { get; set; }

        #endregion

        #region Constructor
        public MillViewModel(MillModel model)
        {
            _model = model;
            Elements = new ObservableCollection<ViewElement>();
            Elements.Add(new ViewElement()
            {
                X = 0,
                Y = 0,
                Parameter = "0,0",
                ButtonMargin = "56,44,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 0,
                Y = 3,
                Parameter = "0,3",
                ButtonMargin = "306,44,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            }); 
            Elements.Add(new ViewElement()
            {
                X = 0,
                Y = 6,
                Parameter = "0,6",
                ButtonMargin = "554,44,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 1,
                Y = 1,
                Parameter = "1,1",
                ButtonMargin = "129,118,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 1,
                Y = 3,
                Parameter = "1,3",
                ButtonMargin = "306,118,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 1,
                Y = 5,
                Parameter = "1,5",
                ButtonMargin = "480,118,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 2,
                Y = 2,
                Parameter = "2,2",
                ButtonMargin = "202,192,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 2,
                Y = 3,
                Parameter = "2,3",
                ButtonMargin = "306,192,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 2,
                Y = 4,
                Parameter = "2,4",
                ButtonMargin = "406,192,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 0,
                Parameter = "3,0",
                ButtonMargin = "56,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 1,
                Parameter = "3,1",
                ButtonMargin = "129,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 2,
                Parameter = "3,2",
                ButtonMargin = "203,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 4,
                Parameter = "3,4",
                ButtonMargin = "406,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 5,
                Parameter = "3,5",
                ButtonMargin = "480,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 3,
                Y = 6,
                Parameter = "3,6",
                ButtonMargin = "554,294,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 4,
                Y = 2,
                Parameter = "4,2",
                ButtonMargin = "204,393,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 4,
                Y = 3,
                Parameter = "4,3",
                ButtonMargin = "306,393,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 4,
                Y = 4,
                Parameter = "4,4",
                ButtonMargin = "406,393,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 5,
                Y = 1,
                Parameter = "5,1",
                ButtonMargin = "129,469,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 5,
                Y = 3,
                Parameter = "5,3",
                ButtonMargin = "306,469,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 5,
                Y = 5,
                Parameter = "5,5",
                ButtonMargin = "480,469,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 6,
                Y = 0,
                Parameter = "6,0",
                ButtonMargin = "56,544,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 6,
                Y = 3,
                Parameter = "6,3",
                ButtonMargin = "306,544,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 6,
                Y = 6,
                Parameter = "6,6",
                ButtonMargin = "554,544,0,0",
                Dummy = -1,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
          //  _model.PlaceToken(0, 1);


            //így lehet hivatkozni mondjuk az aktuális elemre
            //_model.CurrentPlayer;

        }

        #endregion

        #region Methods

        private void MillFieldChosen(object obj)
        {
            String field = (String)obj;
            String[] fieldSplit = field.Split(',');
            int x = int.Parse(fieldSplit[0]);
            int y = int.Parse(fieldSplit[1]);
            Console.WriteLine(_model.CurrentPlayer);
            if (_model.PlaceToken(x, y))
            {
                _model.CurrentPlayer = _model.NextPlayer();
                UpdateView(_model.GameTable);
            }
           
           

            
            
        }

        private void UpdateView(Field[,] _gametable)
        {
            String s = "";
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                   
                    if(_gametable[i,j]==Field.Player1){
                        Elements.Where(p => p.X == i && p.Y == j).First().Dummy = 0;
                    }
                    else if (_gametable[i, j]==Field.Player2)
                    {
                        Elements.Where(p => p.X == i && p.Y == j).First().Dummy = 1;
                    }
                    
                }
            }
        }

        #endregion
    }
}
