using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Cheeteye.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class MembershipPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand LoginNowCommand { get; set; }
        public MembershipModel Model { get; set; }

        private UserService _userService;

        public MembershipPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "REGISTER";
            BackCommand = new Command(async () => { await OnBack(); });
            NextCommand = new Command(async () => { await OnNext(); });
            LoginNowCommand = new Command(async () => { await OnLoginNow(); });
            Model = new MembershipModel();
            _userService = new UserService();
        }

        private async Task OnNext()
        {
            IsBusy = true;
            try
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrEmpty(Model.MembershipNumber))
                {
                    errors.Append("\r\n");
                    errors.Append(nameof(Model.MembershipNumber));
                }
                var res = 0;
                if (!int.TryParse(Model.MembershipNumber, out res))
                {
                    errors.Append("\r\n");
                    errors.Append($"Invalid {nameof(Model.MembershipNumber)}");
                }
                if (string.IsNullOrEmpty(Model.FirstName))
                {
                    errors.Append("\r\n");
                    errors.Append(nameof(Model.FirstName));
                }
                if (string.IsNullOrEmpty(Model.LastName))
                {
                    errors.Append("\r\n");
                    errors.Append(nameof(Model.LastName));
                }
                if (string.IsNullOrEmpty(Model.Email))
                {
                    errors.Append("\r\n");
                    errors.Append(nameof(Model.Email));
                }
                if (!string.IsNullOrEmpty(errors.ToString()))
                {
                    await DisplayMessage("Missing info", errors.ToString());
                    return;
                }

                BusyMessage = "Enrolling user";
                var response = await _userService.Enroll(int.Parse(Model.MembershipNumber), Model.FirstName, Model.LastName, Model.Email);
                if (response.IsSuccess)
                {
                    var navigationParams = new NavigationParameters();
                    Model.Pin = response.Data.Pin;
                    navigationParams.Add("MembershipInfo", Model);
                    await _navigation.NavigateAsync("OTPPage", navigationParams);
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

        private async Task OnLoginNow()
        {
            await _navigation.NavigateAsync("LoginPage");
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }
    }
}
