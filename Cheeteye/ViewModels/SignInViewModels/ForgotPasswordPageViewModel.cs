using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Services;
using Cheeteye.Validators;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class ForgotPasswordPageViewModel : BaseViewModel
    {
        public DelegateCommand SubmitCommand { get; set; }
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

        private UserService _userService;

        public ForgotPasswordPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "FORGOT PASSWORD";
            SubmitCommand = new DelegateCommand(async () => { await OnSubmit(); });
            BackCommand = new Command(async () => { await OnBack(); });
            _userService = new UserService();
        }
        private async Task OnSubmit()
        {
            try
            {
                if (Email.IsNullOrEmpty())
                {
                    await DisplayMessage("Info", "Please enter email");
                    return;
                }

                if (!Email.ValidateEmail())
                {
                    await DisplayMessage("Info", "Invalid email format");
                    return;
                }

                IsBusy = true;
                BusyMessage = "Please wait..";
                var response = await _userService.ForgotPassword(Email);
                if (response.IsSuccess)
                {
                    await DisplayMessage("Check your email", $"We sent an email to { Email }. Tap the link in that email to reset your password");
                    Email = string.Empty;
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
        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }
    }
}
