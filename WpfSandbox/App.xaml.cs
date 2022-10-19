using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSandbox.Common;
using WpfSandbox.ViewModels;
using WpfSandbox.Views;

namespace WpfSandbox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            IDialogService dialogService = new DialogService(mainWindow);
            dialogService.Register<DialogViewModel, DialogWindow>();

            mainWindow.DataContext = new MainWindowViewModel(dialogService);

            mainWindow.Show();
        }
    }
}
