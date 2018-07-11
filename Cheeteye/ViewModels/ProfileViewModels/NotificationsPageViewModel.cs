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
    public class NotificationsPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand PromotionsCommand { get; set; }
        public ICommand UpdatesCommand { get; set; }
        public ICommand TierCommand { get; set; }
        public ICommand RemindersCommand { get; set; }

        private bool _IsPromotions;
        public bool IsPromotions { get { return _IsPromotions; } set { SetProperty(ref _IsPromotions, value); } }
        private bool _IsUpdates;
        public bool IsUpdates { get { return _IsUpdates; } set { SetProperty(ref _IsUpdates, value); } }
        private bool _IsTier;
        public bool IsTier { get { return _IsTier; } set { SetProperty(ref _IsTier, value); } }
        private bool _IsReminders;
        public bool IsReminders { get { return _IsReminders; } set { SetProperty(ref _IsReminders, value); } }

        private NotificationsService _notificationService;

        private ObservableCollection<NotificationModel> _Notifications;
        public ObservableCollection<NotificationModel> Notifications
        {
            get
            {
                return _Notifications;
            }
            set
            {
                SetProperty(ref _Notifications, value);
            }
        }

        public NotificationsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "NOTIFICATIONS";
            _notificationService = new NotificationsService();
            BackCommand = new Command(async () => { await OnBack(); });
            GetNotifications();
            //PromotionsCommand = new Command(async () => { await OnPromotions(); });
            //UpdatesCommand = new Command(async () => { await OnUpdates(); });
            //TierCommand = new Command(async () => { await OnTier(); });
            //RemindersCommand = new Command(async () => { await OnReminders(); });
        }

        private async void GetNotifications()
        {
            if (Notifications != null)
                return;

            try
            {
                var response = await _notificationService.GetNotifications();

                if (response.IsSuccess)
                {
                    Notifications = new ObservableCollection<NotificationModel>(response.Data);
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

        private async Task OnPromotions()
        {
            await Task.Run(() => { IsPromotions = !IsPromotions; });
        }

        private async Task OnUpdates()
        {
            await Task.Run(() => { IsUpdates = !IsUpdates; });
        }

        private async Task OnTier()
        {
            await Task.Run(() => { IsTier = !IsTier; });
        }

        private async Task OnReminders()
        {
            await Task.Run(() => { IsReminders = !IsReminders; });
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }
    }
}
