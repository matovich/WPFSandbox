using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfSandbox.Common;

namespace WpfSandbox
{
    public partial class MainWindow : Window
    {
        protected ICommand ShowDataCommand;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowDataCommand = new DelegateCommand(x => ShowData());
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }


        private static void ShowData()
        {
            
            throw new NotImplementedException();
        }
    }
}
