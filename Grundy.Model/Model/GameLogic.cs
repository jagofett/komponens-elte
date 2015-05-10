using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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
                    _playerOne = new Player { Name = "Player 2", PlayerType = PlayerType.HumanPlayer };
                    break;
                case GameType.CvP:
                    _playerOne = new Player { Name = "Player 1", PlayerType = PlayerType.HumanPlayer };
                    _playerOne = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
                    break;
                case GameType.CvC:
                    _playerOne = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
                    _playerOne = new Player { Name = "CPU 1", PlayerType = PlayerType.ComputerPlayer };
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
                OnGameEnd();
            }
        }

        public void Step(int pileNumber, int stackSize)
        {
            //todo check
            _state.Piles.Find(pile => pile.Id.Equals(pileNumber)).Take(stackSize);
            _state.AddPile(new Pile(stackSize));
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
