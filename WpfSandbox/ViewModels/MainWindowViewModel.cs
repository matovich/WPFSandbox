    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSandbox.Common;
using WpfSandbox.Views;

namespace WpfSandbox.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        public ICommand ShowDataCommand { get; set; }
        public ICommand DisplayMessageCommand { get; set; }
        private IDialogService dialogService { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            ShowDataCommand = new DelegateCommand(x => { ShowData(); });
            DisplayMessageCommand = new DelegateCommand(p => DisplayMessage(p));
            this.dialogService = dialogService;
        }

        private static void ShowData()
        {

            throw new NotImplementedException();
        }

        private void DisplayMessage(object e)
        {
            var viewModel = new DialogViewModel("Hello!");

            bool? result = dialogService.ShowDialog(viewModel);
            if(result.HasValue)
            {
                if(result.Value)
                {
                    // Accepted
                }
                else
                {
                    // Canceled
                }
            }
        }
    }
}
