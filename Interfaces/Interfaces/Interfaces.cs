using System;
using System.Collections.Generic;

namespace Interfaces
{
	public interface IGame
	{
		void StartGame(IAi aiModule);
		void QuitGame();
		List<Object> GetNextStates(Object actState);
		Object GetState();
		int Evaluate(Object state);

	}


	public interface IAi
	{
		Object doMinimax(IGame game);
		Object doAlphaBeta(IGame game);
	}
}
