using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grundy.Library.Model;
using Grundy.Library.ViewModel;

namespace Grundy.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            Startup += new StartupEventHandler(AppStartup);
        }

        private void AppStartup(object sender, StartupEventArgs startupEventArgs)
        {
            //only for debug, for release, framework will use the start.cs StartGame method!!!
            var prog = new Start();
            prog.StartGame(null);
        }
       
    }
}
