using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillTest
{
    public class Player
    {
        private int _allTokens;
        private int _lostTokens;
        private int _onTableTokens;

        public int AllTokens
        {
            get
            {
                return _allTokens;
            } 
            set
            {
                _allTokens = value;
            }
        }

        public int LostTokens
        {
            get
            {
                return _lostTokens;
            }
            set
            {
                _lostTokens = value;
            }
        }

        public int OnTableTokens
        {
            get
            {
                return _onTableTokens;
            }
            set
            {
                _onTableTokens = value;
            }
        }

        public Player()
        {
            InitializePlayer();
        }

        internal void InitializePlayer()
        {
            _allTokens = 9;
            _lostTokens = 0;
            _onTableTokens = 0;
        }
    }
}
