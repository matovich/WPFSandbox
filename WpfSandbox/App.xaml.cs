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

        //    base.OnStartup(e);

            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<DialogViewModel, DialogWindow>();

            var viewModel = new MainWindowViewModel(dialogService);
            var view = new MainWindow() { DataContext = viewModel };

            view.Show();
        }


    }
}
