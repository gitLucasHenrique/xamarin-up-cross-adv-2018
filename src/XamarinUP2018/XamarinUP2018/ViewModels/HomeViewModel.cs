using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XamarinUP2018.ViewModels
{
    public sealed class HomeViewModel : ViewModelBase
    {
        private string text;
        private readonly IPageDialogService pageDialogService;

        public string Text {
            get => text;
            set => SetProperty(ref text, value);
        }

        public ICommand ShowAlert { get; }

        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            this.pageDialogService = pageDialogService;
            ShowAlert = new DelegateCommand(async () => await ExecuteShowAllert());
        }


        private async Task ExecuteShowAllert()
        {
            await Task.Delay(5000);
            await pageDialogService.DisplayAlertAsync("Hello", "The Message", "Ok");
        }

    }
}
