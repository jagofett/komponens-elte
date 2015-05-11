using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FrameWork.View;
using FrameWork.ViewModel;

namespace FrameWork
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow(); // nézet létrehozása

            FrameViewModel viewModel = new FrameViewModel(); // nézetmodell létrehozása

            window.DataContext = viewModel; // nézetmodell és modell társítása

            window.Show();
        }
    }
}
