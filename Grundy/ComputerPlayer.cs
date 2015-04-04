using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    class ComputerPlayer : AbstractPlayer
    {
        public ComputerPlayer(string name)
        {
            this.name = name;
        }

        public override Tuple<int, int> playTurn(List<Pile> piles)
        {
            Console.WriteLine("\n-------------------------------\nIt is the computer's turn (" + name + ")!");
            Console.WriteLine("\nThe current piles (ID, size):");

            foreach (Pile pile in piles)
            {
                Console.WriteLine("( " + pile.ID + ", " + pile.size + " ) ");
            }

            Pile chosenPile = choosePile(piles);

            int taken = dividePile(chosenPile);

            Console.WriteLine("\nIt choose the pile with ID = " + chosenPile.ID + " and took "
                + taken + " elements from it!\n-------------------------------");

            return new Tuple<int, int>(chosenPile.ID, taken);
        }

        protected override Pile choosePile(List<Pile> piles)
        {
            return piles.First(pile => pile.canDivide());
        }

        protected override int dividePile(Pile pile)
        {
            return pile.size % 2 == 0 ? pile.size/2 - 1 : pile.size/2 ;
        }
    }
}
