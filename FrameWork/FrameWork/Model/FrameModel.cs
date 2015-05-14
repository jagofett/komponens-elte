using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ai;
using Interfaces;

namespace FrameWork.Model
{
    class FrameModel
    {
        List<IGame> games;
        private IAi _ai;
        int currentGame;

        public event EventHandler<GameAddedEventArgs> GameAdded;
        
        public FrameModel()
        {
            currentGame = -1;
        }

        public void init()
        {
            PreLoad();
            _ai = new Ai();
            games = new List<IGame>();
            Type igame = typeof(IGame);
            var types = AppDomain.CurrentDomain.GetAssemblies().
                SelectMany(p => p.GetTypes()).
                Where(p => igame.IsAssignableFrom(p) && !igame.Equals(p));

            foreach (var type in types)
            {
                IGame g = (IGame)Activator.CreateInstance(type);
                String gameName = type.Assembly.FullName.Split(',')[0];
                if (gameName != "FrameWork")
                {
                    games.Add(g);
                    GameAdded(this, new GameAddedEventArgs(games.Count - 1, gameName));
                }
            }
            
            //Test

            /*games= new List<IGame>();
            games.Add(new GameMock());
            games.Add(new GameMock());
            games.Add(new GameMock());
            GameAdded(this, new GameAddedEventArgs(0, "Test1"));
            GameAdded(this, new GameAddedEventArgs(0, "Test2"));
            GameAdded(this, new GameAddedEventArgs(0, "Test3"));*/
        }

        FrameModel(List<IGame> games)
        {
            this.games = games;
        }

        public void startGame(int i)
        {
            if (currentGame == -1)
            {
                currentGame = i;
                games[currentGame].StartGame(_ai);
            }
        }

        public void endGame()
        {
            if (currentGame != -1)
            {
                games[currentGame].QuitGame();
                currentGame = -1;
            }
        }

        public void PreLoad()
        {
            this.AssembliesFromApplicationBaseDirectory();
        }

        void AssembliesFromApplicationBaseDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.AssembliesFromPath(baseDirectory);

            string privateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
            if (Directory.Exists(privateBinPath))
                this.AssembliesFromPath(privateBinPath);
        }

        void AssembliesFromPath(string path)
        {
            var assemblyFiles = Directory.GetFiles(path)
                .Where(file => Path.GetExtension(file).Equals(".dll", StringComparison.OrdinalIgnoreCase) ||
                Path.GetExtension(file).Equals(".exe", StringComparison.OrdinalIgnoreCase));

            foreach (var assemblyFile in assemblyFiles)
            {
                Assembly.LoadFrom(assemblyFile);
            }
        }
    }
}
