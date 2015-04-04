using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    class HumanPlayer : AbstractPlayer
    {
        public HumanPlayer(String name)
        {
            this.name = name;
        }

        public override Tuple<int, int> playTurn(List<Pile> piles)
        {
            Pile chosenPile = choosePile(piles);
            return new Tuple<int, int>(chosenPile.ID, dividePile(chosenPile));
        }

        protected override Pile choosePile(List<Pile> piles)
        {
            int chosenID;

            Console.WriteLine("\n-------------------------------\nHey " + name + ", it is your turn!");
            Console.WriteLine("\nThe current piles (ID, size):");

            foreach (Pile pile in piles)
            {
                Console.WriteLine("( " + pile.ID + ", " + pile.size + " ) ");
            }

            Console.WriteLine("\nChoose a pile by ID:");

            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out chosenID) && chosenID <= piles.Count && chosenID > 0)
                {
                    if (!piles.Find(pile => pile.ID.Equals(chosenID)).canDivide())
                    {
                        Console.WriteLine("\nThis pile has less then three elements, so it cannot be divided!");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nChoose a valid ID from the list above!");
                }
            }

            return piles.Find(pile => pile.ID.Equals(chosenID));
        }

        protected override int dividePile(Pile pile)
        {
            int chosenDivisor;

            Console.WriteLine("\nHow many elements would you like to take from this pile?");

            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out chosenDivisor))
                {
                    Console.WriteLine("\nNot a valid value, choose a number between 0 and the size of the pile!");
                    continue;
                }

                if (chosenDivisor < 1 || chosenDivisor >= pile.size)
                {
                    Console.WriteLine("\nNot a valid number, choose one between 0 and the size of the pile!");
                    continue;
                }

                if ((pile.size - chosenDivisor).Equals(chosenDivisor))
                {
                    Console.WriteLine("\nNot a valid number, you cannot divide a pile into two equal pieces!");
                    continue;
                }

                Console.WriteLine("-------------------------------\n");

                return chosenDivisor;
            }
        }
    }
}
