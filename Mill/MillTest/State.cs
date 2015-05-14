using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillTest
{
   public class State
    {
       int row;
       int col;
       int player;

       public State(int actRow, int actCol, int actPlayer)
       {
           row = actRow;
           col = actCol;
           player = actPlayer;
       }

       public int GetPlayer()
       {
           return player;
       }

       public void SetPlayer(int actPlayer)
       {
           player = actPlayer;
       }

       public int GetRow()
       {
           return row;
       }

       public void SetRow(int actRow)
       {
           row = actRow;
       }

       public int GetCol()
       {
           return col;
       }

       public void SetCol(int actCol)
       {
           col = actCol;
       }

    }
}
