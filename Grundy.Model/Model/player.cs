using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy.Library.Model
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerType PlayerType { get; set; }
    }

    public enum PlayerType 
    {
        HumanPlayer,
        ComputerPlayer
    }
}
