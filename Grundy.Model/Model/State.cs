using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grundy.Interface;

namespace Grundy.Library.Model
{
    public class State : IState
    {
        
        public List<Pile> Piles { get; private set; }

        public Player ActPlayer { get; set; }
        public int MainSize { get; private set; }
        public GameType Type { get; private set; }

        public State(int gameSize, GameType type)
        {
            MainSize = gameSize;
            Type = type;
            Piles = new List<Pile> {new Pile(MainSize)};
        }

        public void Start(Player actPlayer)
        {
            ActPlayer = actPlayer;
        }

        public Pile this[int id] 
        {
            get { return Piles == null ? null :  Piles.FirstOrDefault(p => p.Id == id); }
        }

        public void AddPile(Pile pile)
        {
            Piles.Add(pile);
        }

    }
}
