using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Services;
using Cheeteye.Validators;
using Cheeteye.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand ForgotPasswordCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                SetProperty(ref _Email, value);
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

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "LOGIN";
            SignInCommand = new DelegateCommand(async () => { await OnSignIn(); });
            ForgotPasswordCommand = new DelegateCommand(async () => { await OnForgot(); });
            BackCommand = new Command(async () => { await OnBack(); });
            _userService = new UserService();
        }

        private async Task OnSignIn()
        {
            IsBusy = true;
            try
            {
                //send an event to hockeyapp, monitoring the use of this piece of the app

                if (Email.IsNullOrEmpty() || Password.IsNullOrEmpty())
                {
                    await DisplayMessage("Info", "Please enter email and password");
                    return;
                }

                if (!Email.ValidateEmail())
                {
                    await DisplayMessage("Info", "Invalid email format");
                    return;
                }
                BusyMessage = "Please wait...";
                var response = await _userService.Login(Email, Password);
                if (response.IsSuccess)
                {
                    App.UserProfileInfo = response.Data.UserProfile;
                    Application.Current.MainPage = new HomePage();
                }
                else
                {
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

        private async Task OnForgot()
        {
            await _navigation.NavigateAsync("ForgotPasswordPage");
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }
    }
}
