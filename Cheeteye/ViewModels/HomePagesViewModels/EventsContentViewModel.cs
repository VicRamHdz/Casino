using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Cheeteye.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class EventsContentViewModel : BaseViewModel
    {
        private ObservableCollection<EventsModel> _Events;
        public ObservableCollection<EventsModel> Events
        {
            get
            {
                return _Events;
            }
            set
            {
                SetProperty(ref _Events, value);
            }
        }

        public ICommand SelectEventCommand { get; set; }

        private EventsService _eventsService;

        public EventsContentViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            SelectEventCommand = new Command(async (i) => { await OnSelectEvent((EventsModel)i); });
            _eventsService = new EventsService();
            LoadEvents();
        }

        private async void LoadEvents()
        {
            if (Events != null)
                return;

            try
            {
                var response = await _eventsService.GetEvents();

                if (response.IsSuccess)
                {
                    Events = new ObservableCollection<EventsModel>(response.Data);
                }
                else
                {
                    await DisplayApiMessage(response);
                }
            }
            catch (System.Exception ex)
            {
                await DisplayError(ex);
            }
        }

        private async Task OnSelectEvent(EventsModel item)
        {
            var parameters = new NavigationParameters();
            parameters.Add("event", item);
            await _navigation.NavigateAsync("EventDetailsPage", parameters);
        }
    }
}