using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro;

namespace CryptoExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs args)
        {
            base.OnStartup(args);
            DispatcherUnhandledException += (s, e) =>
            {
                MessageBox.Show($"{e.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };
        }
    }
}
