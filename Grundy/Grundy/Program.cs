using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    class Program
    {
        private static int gameType;
        private static int pileSize;

        static void Main(string[] args)
        {
            new Game(askGameType(),askPileSize());
        }

        private static string askGameType(){
            Console.WriteLine("Hi! This is Grundy's game. Please choose one of the following game types.\n");
            Console.WriteLine("  1 : Player vs Computer");
            Console.WriteLine("  2 : Player vs Player");
            Console.WriteLine("  3 : Computer vs Computer\n");

            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out gameType) && new[] { 1, 2, 3 }.Any(current => gameType.Equals(current)))
                {
                    return new[] { "Player vs Computer", "Player vs Player", "Computer vs Computer" }.ElementAt(--gameType);
                }
                else
                {
                    Console.WriteLine("Choose a number between 1 and 3");
                }
            }
        }

        private static int askPileSize()
        {
            Console.WriteLine("Please define the starting size of the pile (3-1000).");

            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out pileSize) && pileSize > 2 && pileSize < 1001)
                {
                    return pileSize;
                }
                else
                {
                    Console.WriteLine("Choose a number between 3 and 1000");
                }
            }
        }
    }
}
