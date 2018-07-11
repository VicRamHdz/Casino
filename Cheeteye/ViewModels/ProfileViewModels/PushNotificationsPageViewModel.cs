using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class PushNotificationsPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        public PushNotificationsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "NOTIFICATIONS";
            BackCommand = new Command(async () => { await OnBack(); });
            SettingsCommand = new Command(async () => { await OnSettings(); });
        }

        private async Task OnSettings()
        {
            await _navigation.NavigateAsync("SettingsPage");
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }
    }
}
