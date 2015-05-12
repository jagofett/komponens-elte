using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.ViewModel
{
    class GameButton : ViewModelBase
    {
        public int Index { get; set; }

        private String _content;

        public String Content { get { return _content; } set { _content = value; OnPropertyChanged("Content"); } }

        public DelegateCommand ButtonCommand { get; set; }
    }
}
