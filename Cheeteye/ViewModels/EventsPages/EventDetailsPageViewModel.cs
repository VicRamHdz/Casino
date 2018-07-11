using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.DependencyServices;
using Cheeteye.Models;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class EventDetailsPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand RightCommand { get; set; }

        public ICommand BookNowCommand { get; set; }

        private EventsModel _Event;
        public EventsModel Event { get { return _Event; } set { SetProperty(ref _Event, value); } }

        public EventDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "EVENT DETAILS";
            RightIcon = "uiCalendar.png";
            BackCommand = new Command(async () => { await OnBack(); });
            RightCommand = new Command(async () => { await OnRight(); });
            BookNowCommand = new Command(async () => { await OnBookNow(); });
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("event"))
            {
                Event = (EventsModel)parameters["event"];
            }
        }

        private async Task OnRight()
        {
            await DisplayMessage("info", "under construction");
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }

        private async Task OnBookNow()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Calendar);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Calendar))
                    {
                        await DisplayMessage("Cheeteye", "Need access to your calendar");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Calendar);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Calendar))
                        status = results[Permission.Calendar];
                }

                if (status != PermissionStatus.Granted)
                {
                    await DisplayMessage("Info", "Calendar permission denied, you can not BOOK NOW this event");
                    return;
                }

                var calendar = Xamarin.Forms.DependencyService.Get<ICalendarInformation>();

                //Event.Name = "Vic Party";
                //Event.Date = DateTime.Today;

                var msg = calendar.AddEvent(Event.Name, Event.Description, Event.Date, Event.Date.AddMinutes(15), "UTC", "UTC");

                await DisplayMessage("", msg);
            }
            catch (Exception ex)
            {
                await DisplayError(ex);
            }
        }
    }
}
