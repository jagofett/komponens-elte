using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillTest.ViewModel
{
    public class ViewElement : ViewModelBase
    {
        private string _Parameter;
        public string Parameter
        {
            get
            {
                return _Parameter;
            }
            set
            {
                _Parameter = value;
                OnPropertyChanged();
            }
        }

        private string _ButtonMargin;
        public string ButtonMargin
        {
            get
            {
                return _ButtonMargin;
            }
            set
            {
                _ButtonMargin = value;
                OnPropertyChanged();
            }
        }

        private int _Dummy;
        public int Dummy
        {
            get
            {
                return _Dummy;
            }
            set
            {
                _Dummy = value;
                OnPropertyChanged();
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public DelegateCommand MillStepCommand { get; set; }
        public DelegateCommand PlayerChangedCommand { get; set; }
    }
}
