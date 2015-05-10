using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Grundy.Interface;

namespace Grundy.Library.Model
{
    public class GameLogic
    {
        private State _state;
        public bool isStarted { get; private set; }
        private Player _playerOne;
        private Player _playerTwo;

        public Player ActPlayer
        {
            get { return _state.ActPlayer; }
        }

        public EventHandler GameStart;
        public EventHandler GameEnd;
        public EventHandler PlayerChange;

        public void OnGameStart()
        {
            if (GameStart != null)
            {
                GameStart(this, new EventArgs());
            }
        }

        public void OnGameEnd()
        {
            if (GameEnd != null)
            {
                GameEnd(this, new EventArgs());
            }
        }
        public void OnPlayerChange()
        {
            if (PlayerChange != null)
            {
                PlayerChange(this, new EventArgs());
            }
        }

        public GameLogic()
        {
            isStarted = false;
        }

        public void Start(int size, GameType type)
        {
            _state = new State(size, type);
            switch (type)
            {
                case GameType.PvP:
                    _playerOne = new Player { Name = "Player 1", PlayerType = PlayerType.HumanPlayer };
                    _playerTwo = new Player { Name = "Player 2", PlayerType = PlayerType.HumanPlayer };
                    break;
                case GameType.CvP:
                    _playerOne = new Player { Name = "Player 1", PlayerType = PlayerType.HumanPlayer };
                    _playerTwo = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
                    break;
                case GameType.CvC:
                    _playerOne = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
                    _playerTwo = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
                    break;
            }
            isStarted = true;
            _state.ActPlayer = _playerOne;
            OnGameStart();
        }

        private void CheckGameOver()
        {
            if (!_state.Piles.Any(pile => pile.CanDivide()))
            {
                isStarted = false;
                OnGameEnd();
            }
        }

        public bool Step(int pileNumber, int stackSize)
        {
            //todo check
            if (!isStarted)
            {
                return false;
            }
            var targetPile = _state.Piles.ElementAtOrDefault(pileNumber);
            if (targetPile == null || targetPile.Size < stackSize || targetPile.Size - stackSize == stackSize)
            {
                return false;
            }
            targetPile.Take(stackSize);

            _state.Piles.Insert(pileNumber, new Pile(stackSize));


            _state.ActPlayer = ActPlayer.Id == _playerOne.Id ? _playerTwo : _playerOne;
            CheckGameOver();
            if (isStarted)
            {
                OnPlayerChange();
            }
            return true;
        }

        public bool Step(State newState)
        {
            //check if state is valid next step. (only pile is relevant)
            var newPile = newState.Piles;
            var curList = _state.Piles;
            //added only 1 pile
            if (newPile.Count() != curList.Count() +1)
            {
                return false;
            }
            var db = curList.Where((t, i) => t.Size != newPile[i].Size).Count();
            if (db > 2)
            {
                return false;
            }
            var stack = newPile.Where((pile, i) => pile.Size != curList[i].Size).First();
            var pileId = newPile.IndexOf(stack);
            var stackSize = stack.Size;

            return Step(pileId, stackSize); 
        }

        public State GetState()
        {
            return _state;
        }

        public List<State> GetNextStates()
        {
            throw new NotImplementedException();
        }

        public int Evaluate(State state)
        {
            throw new NotImplementedException();
        }

    }

    public enum GameType
    {
        PvP,
        CvP,
        CvC
    }
}
