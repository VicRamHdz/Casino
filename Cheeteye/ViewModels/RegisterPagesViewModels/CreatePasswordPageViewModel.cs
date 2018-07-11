using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Cheeteye.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class CreatePasswordPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand DoneCommand { get; set; }

        private MembershipModel _Model;
        public MembershipModel Model
        {
            get { return _Model; }
            set
            {
                SetProperty(ref _Model, value);
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                SetProperty(ref _Password, value);
            }
        }

        private UserService _userService;

        public CreatePasswordPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "REGISTER";
            BackCommand = new Command(async () => { await OnBack(); });
            DoneCommand = new Command(async () => { await OnDone(); });
            _userService = new UserService();
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }

        private async Task OnDone()
        {
            IsBusy = true;
            try
            {
                if (string.IsNullOrEmpty(Password))
                {
                    await DisplayMessage("Missing info", "Password cannot be empty");
                    return;
                }

                BusyMessage = "Setting up password";
                var response = await _userService.CreateAccount(Model.Email, Model.Pin, Password);
                if (response.IsSuccess)
                {
                    App.UserProfileInfo = response.Data;
                    await _navigation.NavigateAsync("HomePage");
                }
                else
                {
                    IsBusy = false;
                    await DisplayApiMessage(response);
                }
            }
            catch (Exception ex)
            {
                await DisplayError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("MembershipInfo"))
            {
                Model = (MembershipModel)parameters["MembershipInfo"];
                RaisePropertyChanged(nameof(Model));
            }
        }
    }
}
