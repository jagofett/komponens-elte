using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FrameWork.ViewModel
{
    class GameButton : ViewModelBase
    {

        private bool _started;
        public bool Started { get { return _started; } set { _started = value; Color = value ? Colors.LightSalmon : Colors.LightGray; OnPropertyChanged("Color"); OnPropertyChanged("Content"); } }
        public int Index { get; set; }

        private String _content;

        public Color Color { get; set; }

        public String Content { get { return (Started ? "Stop " : "") + _content; } set { _content = value; OnPropertyChanged("Content"); } }

        public DelegateCommand ButtonCommand { get; set; }
    }
}
