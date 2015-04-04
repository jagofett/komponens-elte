using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grundy
{
    class Game
    {
        private string gameType;
        private List<Pile> piles;
        private AbstractPlayer playerOne;
        private AbstractPlayer playerTwo;
        private bool turn;

        public Game(string gameType, int initialSize)
        {
            this.gameType = gameType;
            turn = true;

            piles = new List<Pile>();
            piles.Add(new Pile(initialSize));

            createPlayers();
            play();
        }

        private void createPlayers()
        {
            switch (gameType)
            {
                case "Player vs Computer":
                    playerOne = new HumanPlayer("Player 1");
                    playerTwo = new ComputerPlayer("Player 2");
                    break;
                case "Player vs Player":
                    playerOne = new HumanPlayer("Player 1");
                    playerTwo = new HumanPlayer("Player 2");
                    break;
                case "Computer vs Computer":
                    playerOne = new ComputerPlayer("Player 1");
                    playerTwo = new ComputerPlayer("Player 2");
                    break;
                default:
                    throw new NotSupportedException("Game type " + gameType + " is not supported");
            }
        }

        private void play()
        {
            while (piles.Any(pile => pile.canDivide()))
            {
                if (turn == true)
                {
                    Tuple<int, int> returnValue = playerOne.playTurn(piles);
                    piles.Find(pile => pile.ID.Equals(returnValue.Item1)).take(returnValue.Item2);
                    piles.Add(new Pile(returnValue.Item2));
                }
                else
                {
                    Tuple<int, int> returnValue = playerTwo.playTurn(piles);
                    piles.Find(pile => pile.ID.Equals(returnValue.Item1)).take(returnValue.Item2);
                    piles.Add(new Pile(returnValue.Item2));
                }

                turn = !turn;
            }

            Console.WriteLine("\nGame Over. The winner is: " + (turn ? "Player 1" : "Player 2"));
            Console.Beep();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}