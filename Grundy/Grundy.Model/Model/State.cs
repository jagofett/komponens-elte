using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grundy.Library.Model
{
    public class State 
    {

        public List<Pile> Piles { get; private set; }

        public Player ActPlayer { get; set; }
        public int MainSize { get; private set; }
        public GameType Type { get; private set; }

        public State(int gameSize, GameType type)
        {
            MainSize = gameSize;
            Type = type;
            Piles = new List<Pile> { new Pile(MainSize) };
        }

        public State(State state)
        {
            MainSize = state.MainSize;
            Type = state.Type;
            Piles = new List<Pile>();

            foreach (Pile p in state.Piles)
            {
                Piles.Add(new Pile(p.Size, p.Id));
            }
        }

        public void Start(Player actPlayer)
        {
            ActPlayer = actPlayer;
        }

        public void AddPile(Pile pile)
        {
            Piles.Add(pile);
        }

    }
}
