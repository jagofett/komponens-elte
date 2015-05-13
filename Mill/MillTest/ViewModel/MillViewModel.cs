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

        private Dictionary<Tuple<int, int>, Int32> dummies;

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
                Dummy = 0,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            Elements.Add(new ViewElement()
            {
                X = 0,
                Y = 1,
                Parameter = "0,1",
                ButtonMargin = "305,44,0,0",
                Dummy = 0,
                MillStepCommand = new DelegateCommand(MillFieldChosen)
            });
            _model.PlaceToken(0, 1);


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

            _model.PlaceToken(x, y);

            Elements.Where(p => p.X == x && p.Y == y).First().Dummy = 1;
        }

        #endregion
    }
}
