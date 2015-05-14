using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MillTest
{
    public class MillModel
    {
        private int _currentPlayer;
        private Player[] _players;
        private Field[,] _gameTable;
        private String _lastStep;
        private Boolean _mill;

        public int CurrentPlayer
        { 
            get
            {
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;
            }
        }

        public Player[] Players { get { return _players; } }

        public Field[,] GameTable { get { return _gameTable; } set { _gameTable = value; } }

        public String LastStep { get { return _lastStep; } set { _lastStep = value; } }

        public Boolean Mill { get { return _mill; } set { _mill = value; } }

        public MillModel()
        {
            _currentPlayer = 0;
            _players = new Player[2];
            for (int i = 0; i < 2; ++i )
            {
                _players[i] = new Player();
            }
            _gameTable = new Field[7, 7];
            InitializeGameTable(_gameTable);
            
        }

        private void InitializeGameTable( Field[,] table )
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    table[i, j] = Field.Invalid;
                }
            }

            for (int i = 0; i < 7; i=i+3)
            {
                for (int j = 0; j < 7; j=j+3)
                {
                    if (i!=3 || j!=3)
                    {
                        table[i, j] = Field.Empty;
                    }
                }
            }

            for (int i = 1; i < 6; i = i + 2)
            {
                for (int j = 1; j < 6; j = j + 2)
                {
                    if (i != 3 || j != 3)
                    {
                        table[i, j] = Field.Empty;
                    }
                }
            }

            for (int i = 2; i < 5; i++)
            {
                for (int j = 2; j < 5; j++ )
                {
                    if (i != 3 || j != 3)
                    {
                        table[i, j] = Field.Empty;
                    }
                }
            }
        }

        public bool PlaceToken(int row, int column)
        {
            if (GameTable[row, column] == Field.Empty && RemainingTokens(CurrentPlayer) > 0)
            {
                GameTable[row, column] = PlayerAsField(CurrentPlayer);
                Players[CurrentPlayer].OnTableTokens = Players[CurrentPlayer].OnTableTokens + 1;
                return true;
            }
            else
                return false;
        }

        public int NextPlayer()
        {
            if (CurrentPlayer == 0)
                return 1;
            else
                return 0;
        }

        private Field PlayerAsField(int player)
        {
            if (player == 0)
                return Field.Player1;
            else
                return Field.Player2;
        }

        private int RemainingTokens(int currentPlayer)
        {
            return Players[currentPlayer].AllTokens - Players[currentPlayer].LostTokens - Players[currentPlayer].OnTableTokens;
        }

        internal bool IsInMill(int row, int column)
        {
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
            if(row == 3 && column > 3)
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

        internal bool RemoveToken(int row, int column)
        {
            if (GameTable[row, column] == PlayerAsField(NextPlayer()))
            {
                if(!IsInMill(row, column))
                {
                    GameTable[row, column] = Field.Empty;
                    Players[NextPlayer()].LostTokens = Players[NextPlayer()].LostTokens + 1;
                    Players[NextPlayer()].OnTableTokens = Players[NextPlayer()].OnTableTokens - 1;
                    return true;
                }
                else
                {
                    if(IsAllTokenInMill(NextPlayer()))
                    {
                        GameTable[row, column] = Field.Empty;
                        Players[NextPlayer()].LostTokens = Players[NextPlayer()].LostTokens + 1;
                        Players[NextPlayer()].OnTableTokens = Players[NextPlayer()].OnTableTokens - 1;
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool IsAllTokenInMill(int player)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (GameTable[i, j] == PlayerAsField(player) && !IsInMill(i, j))
                        return false;
                }
            }
            return true;
        }

        internal bool JumpToken(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            if (Players[CurrentPlayer].OnTableTokens != 3 || Players[CurrentPlayer].LostTokens != 6)
                return false;

            if(GameTable[rowFrom, columnFrom] == PlayerAsField(CurrentPlayer) && GameTable[rowTo, columnTo] == Field.Empty)
            {
                GameTable[rowFrom, columnFrom] = Field.Empty;
                GameTable[rowTo, columnTo] = PlayerAsField(CurrentPlayer);
                return true;
            }
            else
            {
                return false;
            }
        }


        internal bool MoveToken(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            if (RemainingTokens(CurrentPlayer) != 0 || Players[CurrentPlayer].OnTableTokens <= 3)
                return false;

            if(GameTable[rowFrom, columnFrom] == PlayerAsField(CurrentPlayer) && IsValidMove(rowFrom, columnFrom, rowTo, columnTo))
            {
                GameTable[rowFrom, columnFrom] = Field.Empty;
                GameTable[rowTo, columnTo] = PlayerAsField(CurrentPlayer);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsValidMove(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            if(GameTable[rowTo,columnTo] != Field.Empty || (rowFrom != rowTo && columnFrom != columnTo))
                return false;

            if (rowFrom < rowTo || columnFrom < columnTo)
                return CheckMoveToRightOrDown(rowFrom, columnFrom, rowTo, columnTo);
            else
                return CheckMoveToLeftOrUp(rowFrom, columnFrom, rowTo, columnTo);
        }

        private bool CheckMoveToLeftOrUp(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            for (int i = rowFrom - 1; i > rowTo; i--)
            {
                if (GameTable[i, columnFrom] != Field.Invalid)
                    return false;
            }

            for (int j = columnFrom - 1; j > columnTo; j--)
            {
                if (GameTable[rowFrom, j] != Field.Invalid)
                    return false;
            }
            return true;
        }

        private bool CheckMoveToRightOrDown(int rowFrom, int columnFrom, int rowTo, int columnTo)
        {
            for (int i = rowFrom + 1; i < rowTo; i++)
            {
                if (GameTable[i, columnFrom] != Field.Invalid)
                    return false;
            }

            for (int j = columnFrom + 1; j < columnTo; j++)
            {
                if (GameTable[rowFrom, j] != Field.Invalid)
                    return false;
            }
            return true;
        }

        private bool IsGameOver()
        {
            return Players[0].LostTokens == 7 || Players[1].LostTokens == 7;
        }

        
    }

    public enum Field
    {
        Invalid,
        Empty,
        Player1,
        Player2
    }
}
