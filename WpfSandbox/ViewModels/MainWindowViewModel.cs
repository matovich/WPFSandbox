using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSandbox.Common;


namespace WpfSandbox.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private Queue<CancellationTokenSource> _cancelationTokens = new Queue<CancellationTokenSource>();

        public ICommand ShowDataCommand { get; set; }
        public ICommand DisplayMessageCommand { get; set; }
        public ICommand LockUpTheUICommand { get; set; }
        public ICommand StartLongRunningOperationCommand { get; set; }
        public ICommand StopLongRunningOperationCommand { get; set; }
        private IDialogService dialogService { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            ShowDataCommand = new DelegateCommand(_ => { ShowData(); });
            DisplayMessageCommand = new DelegateCommand(_ => DisplayMessage());
            LockUpTheUICommand = new DelegateCommand(_ => LockUpTheUI());
            StartLongRunningOperationCommand = new DelegateCommand(_ => {_ = StartLongRunningOperationAsync();});
            StopLongRunningOperationCommand = new DelegateCommand(_ => StopLongRunningOperation());

            this.dialogService = dialogService;
        }

        public void LockUpTheUI()
        {
            while(true)
            {
                Trace.Write("r ");
                Thread.Sleep(500);
            }
        }

        public async Task StartLongRunningOperationAsync()
        {
            // https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/
            // https://devblogs.microsoft.com/dotnet/configureawait-faq/

            var cancelationTokenSource = new CancellationTokenSource();
            _cancelationTokens.Enqueue(cancelationTokenSource);
            var number = _cancelationTokens.Count;

            var task = Task.Run(() =>
            {
                while (!cancelationTokenSource.IsCancellationRequested)
                {
                    Trace.Write($"t{number} ");
                    Thread.Sleep(500);
                }
            });

            await task.ConfigureAwait(false);
            task.Dispose();
        }

        public void StopLongRunningOperation() 
        {
            if (_cancelationTokens.Count > 0)
            {
                _cancelationTokens.Dequeue().Cancel();
            }
            else
            {
                Trace.WriteLine($"{Environment.NewLine}No Task Were Running.");
            }
        }

        private static void ShowData()
        {

            throw new NotImplementedException();
        }

        private void DisplayMessage()
        {
            var viewModel = new DialogViewModel("Hello!");

            bool? result = dialogService.ShowDialog(viewModel);
            if(result.HasValue)
            {
                if(result.Value)
                {
                    Trace.WriteLine("Display Message Accepted");
                }
                else
                {
                    Trace.WriteLine("Display Message Canceled");
                }
            }
        }
    }
}
