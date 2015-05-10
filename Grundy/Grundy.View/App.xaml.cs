using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grundy.Interface;
using Grundy.Library.Model;

namespace Grundy.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IGameModel
    {
        private GameLogic _model;
        public App()
        {
            Startup += new StartupEventHandler(AppStartup);
        }

        private void AppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            _model = new GameLogic();
            _model.Start(10, GameType.PvP);
            _model.Step(0, 2);
            _model.Step(1, 3);
            var state = new State(2, GameType.PvP);
            state.AddPile(new Pile(1));
            state.AddPile(new Pile(2));
            state.AddPile(new Pile(5));
            _model.Step(state);
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void QuitGame()
        {
            throw new NotImplementedException();
        }

        public ICollection<IState> GetNextStates()
        {
            throw new NotImplementedException();
        }

        public int Evaluate(IState state)
        {
            throw new NotImplementedException();
        }
    }
}
