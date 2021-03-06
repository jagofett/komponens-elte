﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy.Library.ViewModel
{
    public class GrundyElement : ViewModelBase
    {
        private Boolean _isEnabled;
        private String _text;
        public String Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand StepCommand { get; set; }
    }
}
