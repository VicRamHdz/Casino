using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Cheeteye.ViewModels
{
    public class LandingPageViewModel : BaseViewModel
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }

        public LandingPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            LoginCommand = new DelegateCommand(async () => { await OnLogin(); });
            RegisterCommand = new DelegateCommand(async () => { await OnRegister(); });
        }

        private async Task OnLogin()
        {
            await _navigation.NavigateAsync("LoginPage");
        }

        private async Task OnRegister()
        {
            await _navigation.NavigateAsync("MembershipPage");
        }
    }
}
