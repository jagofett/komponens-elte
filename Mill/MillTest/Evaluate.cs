using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillTest
{
    public class Evaluate
    {

        int row;
        int col;
        int player;
        int value = 100;
        Field[,] GameTable;

        public Evaluate()
        {
          
        }

        public void SetStep(int actRow, int actCol, int actPlayer)
        {
            row = actRow;
            col = actCol;
            player = actPlayer;
        }


        public int GetValue(Field[,] actGameTable)
        {
            value = 100;
            GameTable = actGameTable;

            value = value + CheckSides(row, col);
            if (CheckMill(row, col))
            {
                value = value * 5;
            }
            Console.WriteLine(row + " -- " + col + " : " + value );
            return value;
        }

        private bool CheckMill(int row, int column)
        {
            Console.WriteLine("Eval Mill");
            if (GameTable[row, column] != Field.Empty && GameTable[row, column] != Field.Invalid)
            {
                return MillInRow(row, column) || MillInColumn(row, column);
            }
            else
            {
                return false;
            }
           
        }

        private bool MillInRow(int row, int column)
        {
            bool isMill = true;
            int i = 0;
            if (row == 3 && column > 3)
                i = 4;
            while (isMill && i < 6 && (i != 3 || row != 3))
            {
                isMill = GameTable[row, i] == Field.Invalid || GameTable[row, i] == GameTable[row, column];
                ++i;
            }
            return isMill;
        }

        private bool MillInColumn(int row, int column)
        {
            bool isMill = true;
            int i = 0;
            if (column == 3 && row > 3)
                i = 4;
            while (isMill && i < 6 && (i != 3 || column != 3))
            {
                isMill = GameTable[i, column] == Field.Invalid || GameTable[i, column] == GameTable[row, column];
                ++i;
            }
            return isMill;
        }


        private int CheckSides(int row, int column)
        {
            int value = 0;
            int i = row;
            int j = column;

            if (column==0 || column ==1  || column == 3)
            {
                while (GameTable[i, j + 1] == Field.Invalid)
                {
                    j++;
                }
                if (GameTable[i, j] == Field.Player1 || GameTable[i, j] == Field.Player2)
                {
                    value = value + 50;
                }
            }
            else if (column == 3 || column == 5 || column == 6)
            {
                while (GameTable[i, j - 1] == Field.Invalid)
                {
                    j--;
                }
                if (GameTable[i, j] == Field.Player1 || GameTable[i, j] == Field.Player2)
                {
                    value = value + 50;
                }
            }

            if (row == 0 || row == 1 || row == 3)
            {
                while (GameTable[i+1, j] == Field.Invalid)
                {
                    i++;
                }
                if (GameTable[i, j] == Field.Player1 || GameTable[i, j] == Field.Player2)
                {
                    value = value + 50;
                }
            }
            else if (row == 6 || row == 5 || row == 3)
            {
                while (GameTable[i - 1, j] == Field.Invalid)
                {
                    i--;
                }
                if (GameTable[i, j] == Field.Player1 || GameTable[i, j] == Field.Player2)
                {
                    value = value + 50;
                }
            }


            return value;
        }


        private bool CheckCorner()
        {
            return false;
        }

    }
}
