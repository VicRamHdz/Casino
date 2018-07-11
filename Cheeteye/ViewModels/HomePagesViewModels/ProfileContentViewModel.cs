using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Views;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class ProfileContentViewModel : BaseViewModel
    {
        public ICommand PersonalDetailCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public ProfileContentViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            PersonalDetailCommand = new Command(async () => { await OnPersonalDetail(); });
            SettingsCommand = new Command(async () => { await OnSettings(); });
            LogoutCommand = new Command(async () => { await OnLogout(); });
        }

        private async Task OnPersonalDetail()
        {
            await _navigation.NavigateAsync("ProfileDetailsPage");
        }

        private async Task OnSettings()
        {
            await _navigation.NavigateAsync("SettingsPage");
        }

        private async Task OnLogout()
        {
            if (await DisplayYesNoMessage("Exit Now", "Are you sure want to exit?"))
            {
                ((App)Application.Current).MainPage = new LandingPage();
            }
        }
    }
}
