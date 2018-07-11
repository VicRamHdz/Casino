using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Cheeteye.Services;
using Cheeteye.Validators;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class ProfileDetailsPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public UserProfileInfoModel Model { get; set; }
        public ICommand SaveDetailsCommand { get; set; }
        private UserService _userService;

        public ProfileDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "PROFILE DETAILS";
            BackCommand = new Command(async () => { await OnBack(); });
            SaveDetailsCommand = new Command(async () => { await OnSaveDetails(); });
            _userService = new UserService();
            Model = App.UserProfileInfo;
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }

        private async Task OnSaveDetails()
        {
            try
            {
                if (Model.FirstName.IsNullOrEmpty())
                {
                    await DisplayMessage("Info", "Please enter First Name");
                    return;
                }

                if (Model.LastName.IsNullOrEmpty())
                {
                    await DisplayMessage("Info", "Please enter Last Name");
                    return;
                }

                if (!Model.Email.ValidateEmail())
                {
                    await DisplayMessage("Info", "Invalid email format");
                    return;
                }

                IsBusy = true;
                BusyMessage = "Please wait..";
                var response = await _userService.UpdateProfile(Model);
                if (response.IsSuccess)
                {
                    App.UserProfileInfo = response.Data;
                    await DisplayMessage("Info", "Profile modified successfully");
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
    }
}
