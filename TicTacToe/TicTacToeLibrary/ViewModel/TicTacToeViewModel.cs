﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Model;

namespace TicTacToe.ViewModel
{
    public class TicTacToeViewModel : ViewModelBase
    {
        #region Properties

        private Logic _model;

        private const int EASY_WRONG_STEP_AFTER_STEPS = 5;
        private const int MEDIUM_WRONG_STEP_AFTER_STEPS = 10;
        
        private ObservableCollection<TicTacToeElement> _Elements;
        public ObservableCollection<TicTacToeElement> Elements
        {
            get
            {
                return _Elements;
            }
            set
            {
                _Elements = value;
                OnPropertyChanged("Elements");
            }
        }

        public int Size { get; set; }

        private bool _PP;
        public bool PP
        {
            get { return _PP; }
            set
            {
                _PP = value;
                OnPropertyChanged("PP");
            }
        }

        private bool _PC;
        public bool PC
        {
            get { return _PC; }
            set
            {
                _PC = value;
                OnPropertyChanged("PC");
            }
        }

        private bool _CC;
        public bool CC
        {
            get { return _CC; }
            set
            {
                _CC = value;
                OnPropertyChanged("CC");
            }
        }

        private string _InfoText;
        public string InfoText
        {
            get { return _InfoText; }
            set
            {
                _InfoText = value;
                OnPropertyChanged("InfoText");
            }
        }

        private bool _Easy;
        public bool Easy
        {
            get { return _Easy; }
            set
            {
                _Easy = value;
                OnPropertyChanged("Easy");
            }
        }

        private bool _Medium;
        public bool Medium
        {
            get { return _Medium; }
            set
            {
                _Medium = value;
                OnPropertyChanged("Medium");
            }
        }

        private bool _Hard;
        public bool Hard
        {
            get { return _Hard; }
            set
            {
                _Hard = value;
                OnPropertyChanged("Hard");
            }
        }

        private bool _ShowEvaluate;
        public bool ShowEvaluate
        {
            get { return _ShowEvaluate; }
            set
            {
                _ShowEvaluate = value;
                OnPropertyChanged("ShowEvaluate");
            }
        }
        private bool nextIsCPU = false;

        private int wrongStepHelper = 0;

        private List<Tuple<int, int, int>> fieldValues;

        Random r = new Random(Guid.NewGuid().GetHashCode());
        /// <summary>
        /// Ha hamis, akkor az első játékos jön (PP, PC, CC-ből az első), ha igaz, akkor a második (PP,PC,CC-ből a második)
        /// </summary>
        private bool Player { get; set; }

        #endregion

        #region DelegateCommands

        public DelegateCommand PlayerChangedCommand { get; set; }
        public DelegateCommand DifficultyChangedCommand { get; set; }
        public DelegateCommand EvaluationCommand { get; set; }

        #endregion

        #region Events

        public class WinEventArgs : EventArgs
        {
            /// <summary>
            /// igaz, ha O játékos, hamis ha X játékos
            /// </summary>
            public string Player { get; set; }
            public WinEventArgs(string player)
            {
                Player = player;
            }
        }

        public event EventHandler<WinEventArgs> GameEnded;

        public EventHandler CpuStep;

        private void OnCpuStep()
        {
            if (CpuStep != null)
            {
                CpuStep(this, new EventArgs());
            }
        }


        #endregion

        #region Constructor
        public TicTacToeViewModel(Logic model)
        {
            _model = model;
            PP = true;
            PC = false;
            CC = false;
            Easy = true;
            Hard = false;
            ShowEvaluate = false;
            fieldValues = new List<Tuple<int, int, int>>();
            PlayerChangedCommand = new DelegateCommand(PlayerSettingsChanged);
            DifficultyChangedCommand = new DelegateCommand(DifficultyChanged);
            EvaluationCommand = new DelegateCommand(EvaluationChanged);
            Size = Logic.SIZE;
            CreateGameTable(Logic.SIZE);
            NewGame();
        }

        private void EvaluationChanged(object obj)
        {
            ShowEvaluate = !ShowEvaluate;
            if (!ShowEvaluate)
            {
                foreach (var element in Elements)
                {
                    if (element.Text != "X" && element.Text != "O")
                    {
                        element.Text = "";
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Akkor hívódik meg, amikor megváltozik a játékosok felállása. Beállítja, hogy ki játszik ki ellen és indít egy új játékot
        /// </summary>
        /// <param name="obj"></param>
        private void PlayerSettingsChanged(object obj)
        {
            String player = (String)obj;
            switch (player)
            {
                case "PP":
                    PP = true;
                    PC = false;
                    CC = false;
                    break;
                case "PC":
                    PP = false;
                    PC = true;
                    CC = false;
                    break;
                case "CC":
                    PP = false;
                    PC = false;
                    CC = true;
                    break;
                default: break;
            }
            NewGame();
        }

        /// <summary>
        /// Akkor hívódik meg, amikor megváltozik a nehézség.
        /// </summary>
        /// <param name="obj"></param>
        private void DifficultyChanged(object obj)
        {
            String diff = (String)obj;
            switch(diff)
            {
                case "Easy":
                    Easy = true;
                    Medium = false;
                    Hard = false;
                    break;
                case "Medium":
                    Easy = false;
                    Medium = true;
                    Hard = false;
                    break;
                case "Hard":
                    Easy = false;
                    Medium = false;
                    Hard = true;
                    break;
                default: break;
            }
            NewGame();
        }

        /// <summary>
        /// Létrehoz egy új táblát a megadott mérettel.
        /// </summary>
        /// <param name="size"></param>
        public void CreateGameTable(int size)
        {
            Elements = new ObservableCollection<TicTacToeElement>();
            int idCounter = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Elements.Add(new TicTacToeElement() { 
                        Text = "", 
                        X = i, 
                        Y = j, 
                        Id = idCounter,
                        IsEnabled = true,
                        Color = "White",
                        StepCommand = new DelegateCommand(param => FieldChosen(Convert.ToInt32(param)))
                    });
                    idCounter++;
                }
            }
        }

        /// <summary>
        /// Elindít egy új játékot, amivel együtt lenullázza a pályát is
        /// </summary>
        public void NewGame()
        {
            Player = false;
            nextIsCPU = false;
            _model.NewGame();
            foreach (TicTacToeElement element in Elements)
            {
                element.Text = "";
                element.IsEnabled = true;
                element.Color = "White";
            }
            SetInfoFromActualState();
        }

        /// <summary>
        /// A játékos kiválaszt egy mezőt a táblán, és meghívódik rá a következő lépés. Csak a felületen történő kattintásra hívódik meg
        /// </summary>
        /// <param name="id"></param>
        public void FieldChosen(int id)
        {
            if (nextIsCPU) return;
            TicTacToeElement element = Elements[id];
            if (!element.IsEnabled) return;

            NextStep(element);
        }

        /// <summary>
        /// Lép egyet a kiválasztott elemmel a következő játékos
        /// </summary>
        /// <param name="element"></param>
        private void NextStep(TicTacToeElement element)
        {
            if (!Player)
            {
                element.Text = "X";
                element.Color = "Red";
            }
            else
            {
                element.Text = "O";
                element.Color = "Green";
            }

            ChangePlayer();

            element.IsEnabled = false;

            int player = Player ? 2 : 1;
            _model.UpdateTable(element.X, element.Y, player);


            #region Evaluations on screen for testing

            fieldValues.Clear();
            foreach (TicTacToeElement _element in Elements)
            {
                if (_model.CanPlace(_element.X, _element.Y))
                {
                    if (_model.ValueTableValue(_element.X, _element.Y) == "0")
                    {
                        if(ShowEvaluate) _element.Text = "";
                    }
                    else
                    {
                        if (ShowEvaluate) _element.Text = _model.ValueTableValue(_element.X, _element.Y);
                        fieldValues.Add(new Tuple<int, int, int>(_element.X, _element.Y, int.Parse(_model.ValueTableValue(_element.X, _element.Y))));
                    }
                }
            }

            #endregion


            bool end = _model.IsGameOver();
            if (end)
            {
                if (GameEnded != null)
                {
                    GameEnded(this, new WinEventArgs(PlayerToString(Player)));
                    return;
                }
            }

            if (PC && Player)
            {
                nextIsCPU = true;
                CPUStep();
            }
            else if (PC && !Player)
            {
                nextIsCPU = false;
            }
            else if (CC)
            {
                nextIsCPU = true;
                CPUStep();
            }
        }

        /// <summary>
        /// A CPU lép egyet
        /// </summary>
        private void CPUStep()
        {
            Tuple<int, int, int> chosenField;
            bool bestStep = true;
            if (!Hard)
            {
                int maxStep;
                if (Medium) maxStep = MEDIUM_WRONG_STEP_AFTER_STEPS;
                else if (Easy) maxStep = EASY_WRONG_STEP_AFTER_STEPS;
                else maxStep = 5;

                if (wrongStepHelper < maxStep)
                {
                    wrongStepHelper++;
                }
                else
                {
                    bestStep = false;
                    wrongStepHelper = 0;
                }
            }

            if (bestStep)
            {
                int max = fieldValues.First().Item3;
                foreach (var field in fieldValues)
                {
                    if (max < field.Item3)
                    {
                        max = field.Item3;
                    }
                }
                chosenField = fieldValues.Where(x => x.Item3 == max).First();
            }
            else
            {
                int randomElement = r.Next(0, fieldValues.Count);
                chosenField = fieldValues.ElementAt(randomElement);
            }

            

            NextStep(Elements.Where(x => x.X == chosenField.Item1 && x.Y == chosenField.Item2).First());
        }

        /// <summary>
        /// Átvált a következő játékosra
        /// </summary>
        private void ChangePlayer()
        {
            Player = !Player;
            SetInfoFromActualState();
        }

        /// <summary>
        /// Beállítja az információs szöveget alul az aktuális állapotok alapján
        /// </summary>
        private void SetInfoFromActualState()
        {
            InfoText = "Next is " + PlayerToString(!Player);
        }

        /// <summary>
        /// A paraméterben megadott játékos bool értékből visszaadja, hogy melyik játékos jön szövegként, plusz hozzáteszi, hogy emberi vagy gépi játékos jön
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private string PlayerToString(bool player)
        {
            if (PP)
            {
                return player ? "X player" : "O player";
            }
            else if (PC)
            {
                return player ? "X player" : "O CPU";
            }
            else
            {
                return player ? "X CPU" : "O CPU";
            }
        }

        #endregion

        #region Unit tests

        private void assert(bool expr)
        {
            if (!expr)
            {
                throw new System.Exception("Testing assertion failed");
            }
        }
        public void RunTests()
        {
            //megtörténik a játékosváltás helyesen
            PlayerSettingsChanged("PP");
            assert(PP && !PC && !CC);
            PlayerSettingsChanged("PC");
            assert(!PP && PC && !CC);
            PlayerSettingsChanged("CC");
            assert(!PP && !PC && CC);
            PlayerSettingsChanged("asd");
            assert(!PP && !PC && CC);
            PlayerSettingsChanged("PP");
            assert(Elements != null); //létrejönnek az elemek
            //megfelelő a tábla mérete (n*n)
            CreateGameTable(1);
            assert(Elements.Count == 1); 
            CreateGameTable(50);
            assert(Elements.Count == 2500);
            //minden elem üres-e
            assert(Elements[12].Id == 12);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            assert(Elements.Where(p => p.Text == "").Count() == Elements.Count);
            assert(Elements.Where(p =>
                p.X == (p.Id / 50) && p.Y == p.Id - ((p.Id / 50) * 50) 
            ).Count() == Elements.Count);
            //néhány lépés
            FieldChosen(0);
            FieldChosen(1);
            FieldChosen(2);
            FieldChosen(3);
            FieldChosen(4);
            //új játék hívása után újra üres-e a tábla
            NewGame();
            assert(Elements.Count == 2500);
            assert(Elements[12].Id == 12);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            assert(Elements.Where(p => p.Text == "").Count() == Elements.Count);
            assert(Elements.Where(p =>
                p.X == (p.Id / 50) && p.Y == p.Id - ((p.Id / 50) * 50)
            ).Count() == Elements.Count);

            //két jó elem és egy rossz elem kiválasztása után kettővel kevesebb mezőre lehet lépni
            NewGame();
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            FieldChosen(0);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count-1);
            FieldChosen(1);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count - 2);
            FieldChosen(1);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count - 2);

            //A nextstep lép-e az adott mezőre
            PlayerSettingsChanged("PP");
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            NextStep(Elements[0]);
            assert(Elements[0].Text == "X");
            NextStep(Elements[1]);
            assert(Elements[1].Text == "O");
            NextStep(Elements[2]);
            assert(Elements[2].Text == "X");

            //a gépi játékos rak-e önmagától valahova
            PlayerSettingsChanged("PC");
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            FieldChosen(0);
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count-2);

            //befejeződik-e a játék
            PlayerSettingsChanged("PP");
            bool vege = false;
            GameEnded += delegate(object sender, WinEventArgs e)
            {
                vege = true;
            };
            FieldChosen(0);
            FieldChosen(11);
            FieldChosen(1);
            FieldChosen(12);
            FieldChosen(2);
            FieldChosen(13);
            FieldChosen(3);
            FieldChosen(14);
            FieldChosen(4);
            assert(vege);

            //A kiírandó szövegek ellenőrzése
            PlayerSettingsChanged("PP");
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count);
            SetInfoFromActualState();
            assert(InfoText.Equals("Next is X player"));
            FieldChosen(0);
            SetInfoFromActualState();
            assert(InfoText.Equals("Next is O player"));
            CPUStep();
            assert(Elements.Where(p => p.IsEnabled).Count() == Elements.Count - 2);

            assert(PlayerToString(true).Equals("X player"));
            assert(PlayerToString(false).Equals("O player"));
            PlayerSettingsChanged("PC");
            assert(PlayerToString(true).Equals("X player"));
            assert(PlayerToString(false).Equals("O CPU"));
            PlayerSettingsChanged("CC");
            assert(PlayerToString(true).Equals("X CPU"));
            assert(PlayerToString(false).Equals("O CPU"));
        }
        #endregion
    }
}
