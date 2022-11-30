using System;
using System.Windows.Input;
using WpfSandbox.Common;

namespace WpfSandbox.ViewModels
{
    public class DialogViewModel : IDialogRequestClose
    {
        public string Message { get; }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public DialogViewModel(string message)
        {
            Message = message;
            OkCommand = new DelegateCommand(_ => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)));
            CancelCommand = new DelegateCommand(_ => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)));
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

    }
}
