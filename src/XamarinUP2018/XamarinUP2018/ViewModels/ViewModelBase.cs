using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XamarinUP2018.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected ViewModelBase(INavigationService navigationService) {
            NavigationService = navigationService;
        }

        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public bool IsNotBusy => !IsBusy;

        protected async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (IsBusy)
                return;
            try
            {
                await theBusyAction();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }

        }
        public INavigationService NavigationService { get; }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

    }
}
