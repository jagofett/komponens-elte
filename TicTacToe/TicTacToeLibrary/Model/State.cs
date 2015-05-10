using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class State
    {
        private int player;

        private int[,] table;
        private int[,] valueTable;
        private int value;

        public State(int size)
        {
            table = new int[size, size];
            valueTable = new int[size, size];
            player = 2;
            value = 0;
        }

        public int GetPlayer()
        {
            return player;
        }

        public void SetPlayer(int actPlayer)
        {
            player = actPlayer;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int actValue)
        {
            value = actValue;
        }

        public int GetTableValue(int row, int col)
        {
            return table[row, col];
        }

        public void SetTableValue(int row, int col, int val)
        {
            table[row, col] = val;
        }

        public int GetValueTableValue(int row, int col)
        {
            return valueTable[row, col];
        }

        public void SetValueTableValue(int row, int col, int val)
        {
            valueTable[row, col] = val;
        }

        public int[,] ValTable()
        {
            return valueTable;
        }


    }
}
