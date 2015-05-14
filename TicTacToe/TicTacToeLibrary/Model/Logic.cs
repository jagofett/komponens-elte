using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class Logic
    {
       
        private int row;
        private int col;
        private int player;

        private int[,] testTable;

        private Evaluate eval;
        private State state;

        public static int SIZE = 50;

        public Logic()
        {

            state = new State(SIZE);

            testTable = new int[SIZE, SIZE];

            NewGame();
           
            eval = new Evaluate();

        }
        public void NewGame()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {

                    state.SetTableValue(i,j,0);
                    state.SetValueTableValue(i,j,0);
              
                }
            }
        }

        public void UpdateTable(int actRow, int actCol, int actPlayer)
        {
            row = actRow;
            col = actCol;
            player = actPlayer;

            state.SetTableValue(row, col, player);  //set new piece on table

            

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (state.GetTableValue(i, j) == 0)
                        TestStep(i, j, actPlayer);
                }
            }

            testTable = state.ValTable();
            
        }

        public bool CanPlace(int row, int col)  //only used during testing process
        {
            if (state.GetTableValue(row, col) == 0)
                return true;

            return false;
        }

        public string ValueTableValue(int row, int col)
        {
            return state.GetValueTableValue(row, col).ToString();  //only used during testing process
        }

        public void TestStep(int testRow, int testCol, int testPlayer)
        {
 

            //get the area where this new piece can potentially create 5 in a row, or column or the two diagonals
            //thus creating a star with the new piece in the middle
            List<string> star = eval.Star(state, testRow, testCol, testPlayer); 
 
            //using this star, get the strength of this actual piece
            eval.GetFieldValue(star, testPlayer);

            //set this strength value in the value table containing only the strength of pieces, not the actual pieces
            UpdateValueTable(testRow, testCol);

            int testval = state.GetValueTableValue(testRow, testCol);


            
        }

       

        public Boolean IsGameOver()
        {

            if (IsRow())
                return true;

            if (IsCol())
                return true;

            if (IsDiagonal())
                return true;

            if (IsAntiDiagonal())
                return true;

            return false;
        }

        private Boolean IsRow()
        {
            
            int counter = 0;
            int i = row;
            int j = col;

            //check row to the right
            while (j < SIZE && state.GetTableValue(i,j) == player)
            {
                counter++;
                j++;
            }         

            //back to left of the latest piece position (we don't count the original piece twice)
            j = col - 1;

            //check row to the left
            while (-1 < j && state.GetTableValue(i, j) == player)
            {
                counter++;
                j--;
            }


            if (counter >= 5)
                return true;

            return false;
        }

        private Boolean IsCol()
        {

            int i = row;
            int j = col;
            int counter = 0;

            //check column upwards
            while (i > -1 && state.GetTableValue(i, j) == player)
            {
                counter++;
                i--;
            }

            //back to one piece under the original piece
            i = row + 1;

            //check column downwards
            while (i < SIZE && state.GetTableValue(i, j) == player)
            {
                counter++;
                i++;
            }

            if (counter >= 5)
                return true;


            return false;
        }

        private Boolean IsDiagonal()
        {
            int counter = 0;
            int i = row;
            int j = col;

            //check diagonal upwards
            while (i > -1 && j < SIZE && state.GetTableValue(i, j) == player)
            {
                counter++;
                i--;
                j++;
            }

            //back to one pice under and left of original piece 
            i = row + 1;
            j = col - 1;

            //check diagonal downwards
            while (i < SIZE && j > -1 && state.GetTableValue(i, j) == player)
            {
                counter++;
                i++;
                j--;
            }

            if (counter >= 5)
                return true;

            return false;
        }

        private Boolean IsAntiDiagonal()
        {
            int counter = 0;
            int i = row;
            int j = col;


            //check antidiagonal upwards
            while (i > -1 && j > -1 && state.GetTableValue(i, j) == player)
            {
                counter++;
                i--;
                j--;
            }

            //back to one piece under and right of original piece
            i = row + 1;
            j = col + 1;

            //check antidiagonal downwards and right
            while (i < SIZE && j < SIZE && state.GetTableValue(i, j) == player)
            {
                counter++;
                i++;
                j++;
            }

            if (counter >= 5)
                return true;


            return false;
        }

        public void UpdateValueTable(int row, int col)
        {

            int oldValue = state.GetValueTableValue(row,col);

            int newValue = eval.GetFieldValue(eval.Star(state, row, col, 2), 2) -
                            eval.GetFieldValue(eval.Star(state, row, col, 1), 1);

            state.SetValueTableValue(row, col, Math.Abs(newValue));

            state.SetValue(state.GetValue() - (oldValue - newValue));

        }

        private void assert(bool expr)
        {
            if (!expr)
            {
                throw new System.Exception("Testing assertion failed");
            }
        }

        public void RunTests()
        {
            //start new game
            NewGame();
            //state exists
            assert(state!=null);

            //put piece in desired position
            UpdateTable(2, 2, 2);
            assert(state.GetTableValue(2, 2) == 2);
            UpdateTable(2, 3, 1);
            assert(state.GetTableValue(2, 3) == 1);

            //value table value string conversion
            assert(ValueTableValue(2, 2) == state.GetValueTableValue(2, 2).ToString());

            //check gameover (should not be)
            assert(!IsGameOver());

            //start creating gameover situation
            UpdateTable(3, 2, 2);
            UpdateTable(4, 2, 2);
            UpdateTable(5, 2, 2);
            

            //build star for pattern recognition
            List<string> star = eval.Star(state, 6, 2, 2);
            assert(star.Count == 4);


            //evaluate strength of chosen field
            UpdateValueTable(6, 2);
            assert(state.GetValueTableValue(6, 2) == 1130);

            //place piece to create gameover situation
            UpdateTable(6, 2, 2);

            //check gameover again (should be)
            assert(IsGameOver());

           
        }

    }
}
