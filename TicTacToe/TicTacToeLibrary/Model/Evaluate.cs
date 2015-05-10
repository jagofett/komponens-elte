using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class Evaluate
    {

        private static Dictionary<string, int> patterns1;
        private static Dictionary<string, int> patterns2;

        private int size;
     

        public Evaluate()
        {

            size = Logic.SIZE;


            patterns1 = new Dictionary<string, int>();
            patterns2 = new Dictionary<string, int>();
            
            //patterns for player 1

            patterns1.Add("10000", 1); patterns1.Add("01000", 1);
            patterns1.Add("00100", 1); patterns1.Add("00010", 1);
            patterns1.Add("00001", 1);

            patterns1.Add("11000", 5); patterns1.Add("10100", 5);
            patterns1.Add("10010", 5); patterns1.Add("10001", 5);
            patterns1.Add("01100", 5); patterns1.Add("01010", 5);
            patterns1.Add("01001", 5); patterns1.Add("00110", 5);
            patterns1.Add("00101", 5); patterns1.Add("00011", 5);

            patterns1.Add("11100", 25); patterns1.Add("11010", 25);
            patterns1.Add("11001", 25); patterns1.Add("10110", 25);
            patterns1.Add("10101", 25); patterns1.Add("10011", 25);
            patterns1.Add("01110", 25); patterns1.Add("01101", 25);
            patterns1.Add("01011", 25); patterns1.Add("00111", 25);

            patterns1.Add("11110", 100); patterns1.Add("11101", 100);
            patterns1.Add("11011", 100); patterns1.Add("10111", 100);
            patterns1.Add("01111", 100);

            patterns1.Add("11111", 1000);

            //patterns for player 2

            patterns2.Add("20000", 1); patterns2.Add("02000", 1);
            patterns2.Add("00200", 1); patterns2.Add("00020", 1);
            patterns2.Add("00002", 1);

            patterns2.Add("22000", 5); patterns2.Add("20200", 5);
            patterns2.Add("20020", 5); patterns2.Add("20002", 5);
            patterns2.Add("02200", 5); patterns2.Add("02020", 5);
            patterns2.Add("02002", 5); patterns2.Add("00220", 5);
            patterns2.Add("00202", 5); patterns2.Add("00022", 5);

            patterns2.Add("22200", 25); patterns2.Add("22020", 25);
            patterns2.Add("22002", 25); patterns2.Add("20220", 25);
            patterns2.Add("20202", 25); patterns2.Add("20022", 25);
            patterns2.Add("02220", 25); patterns2.Add("02202", 25);
            patterns2.Add("02022", 25); patterns2.Add("00222", 25);

            patterns2.Add("22220", 100); patterns2.Add("22202", 100);
            patterns2.Add("22022", 100); patterns2.Add("20222", 100);
            patterns2.Add("02222", 100);

            patterns2.Add("22222", 1000);

        }


        public List<string> Star(State state, int row, int col, int player)
        {

            List<string> star_pieces = new List<string>();

            int item = state.GetTableValue(row, col);

            //put the test value on the table
            if (player != 0)
                state.SetTableValue(row, col, player);

            string star_piece = null;
            


            //getting vertical line
            int i = row;
            int j = col;
           

            while (i > -1 && row - i <= 4)
                i--;

            i++;

            while (i < size && i <= row + 4)
            {
                star_piece += state.GetTableValue(i,j).ToString();
                i++;
            }

            star_pieces.Add(star_piece);
            star_piece = string.Empty;

            //getting horizontal line
            i = row;
            j = col;

            while (j > -1 && col - j <= 4)
            {
                j--;
            }

            j++;

            while (j < size && j <= col + 4)
            {
                star_piece += state.GetTableValue(i, j).ToString();
                j++;
            }

            star_pieces.Add(star_piece);
            star_piece = string.Empty;
            
            //getting diagonal line
            i = row;
            j = col;

            while (j > -1 && i < size && col - j <= 4)
            {
                j--;
                i++;
            }

            j++;
            i--;

            while (j < size && i > -1 && j <= col + 4)
            {
                star_piece += state.GetTableValue(i, j).ToString();
                j++;
                i--;
            }

            star_pieces.Add(star_piece);
            star_piece = string.Empty;

            //getting antidiagonal line
            i = row;
            j = col;

            while (j > -1 && i > -1 && col - j <= 4)
            {
                j--;
                i--;
            }

            j++;
            i++;

            while (j < size && i < size && j <= col + 4)
            {
                star_piece += state.GetTableValue(i, j).ToString();
                j++;
                i++;
            }

            star_pieces.Add(star_piece);
            star_piece = string.Empty;

            //set the table to original state
            state.SetTableValue(row, col, item);

            return star_pieces;
        }

        public int GetFieldValue(List<string> star, int player)
        {

            int value = 0;

            //pattern recognition

            for (int i = 0; i < 4; i++)
            {
                int length = star[i].Length;

                while (length >= 5)
                {

                    string key = star[i].Substring(length - 5, 5);

                    if (player == 1 && patterns1.ContainsKey(key))
                        value += patterns1[key];

                    if (player == 2 && patterns2.ContainsKey(key))
                        value += patterns2[key];


                    length--;
                }

                
            }

            return value;
        }



       

    }
}
