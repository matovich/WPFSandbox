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
        public ICommand ShowDataCommand { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ShowDataCommand = new DelegateCommand(x => ShowData());
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 
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
