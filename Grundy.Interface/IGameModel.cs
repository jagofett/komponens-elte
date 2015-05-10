using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grundy.Interface
{
    public interface IGameModel
    {
        void StartGame();
        void QuitGame();
        ICollection<IStep> GetNextSteps();

    }

    public interface IStep
    {
        
    }
}
