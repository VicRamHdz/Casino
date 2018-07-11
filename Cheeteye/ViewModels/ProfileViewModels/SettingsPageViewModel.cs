using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Cheeteye.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand NotificationsCommand { get; set; }
        public ICommand LanguagesCommand { get; set; }
        public ICommand TimeZoneCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        private ObservableCollection<LanguageModel> _Languages;
        public ObservableCollection<LanguageModel> Languages
        {
            get { return _Languages; }
            set { SetProperty(ref _Languages, value); }
        }

        private LanguageModel _SelectedLanguage;
        public LanguageModel SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {
                if (_SelectedLanguage != value && value != null)
                {
                    Model.LanguageId = value.Id;
                    //Task.Run(async () => await OnSave());
                    //OnSave();
                }
                SetProperty(ref _SelectedLanguage, value);
            }
        }

        private bool _SetFocusLanguage;
        public bool SetFocusLanguage
        {
            get { return _SetFocusLanguage; }
            set
            {
                SetProperty(ref _SetFocusLanguage, value);
            }
        }

        private ObservableCollection<TimeZoneModel> _TimeZones;
        public ObservableCollection<TimeZoneModel> TimeZones
        {
            get { return _TimeZones; }
            set { SetProperty(ref _TimeZones, value); }
        }

        private TimeZoneModel _SelectedTimeZone;
        public TimeZoneModel SelectedTimeZone
        {
            get { return _SelectedTimeZone; }
            set
            {
                if (_SelectedTimeZone != value && value != null)
                {
                    Model.TimeZoneId = value.Id;
                    //Task.Run(async () => await OnSave());
                    //OnSave();
                }
                SetProperty(ref _SelectedTimeZone, value);
            }
        }

        private bool _SetFocusTimeZone;
        public bool SetFocusTimeZone
        {
            get { return _SetFocusTimeZone; }
            set { SetProperty(ref _SetFocusTimeZone, value); }
        }

        public UserProfileInfoModel Model { get; set; }

        private SettingsService _settingsService;
        public SettingsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "SETTINGS";
            BackCommand = new Command(async () => { await OnBack(); });
            NotificationsCommand = new Command(async () => { await OnNotifications(); });
            LanguagesCommand = new Command(async () => { await OnLanguages(); });
            TimeZoneCommand = new Command(async () => { await OnTimeZone(); });
            SaveCommand = new Command(async () => { await OnSave(); });
            _settingsService = new SettingsService();
            Model = App.UserProfileInfo;
            LoadLanguages();
            LoadTimeZones();
        }

        private async void LoadLanguages()
        {
            if (Languages != null)
                return;

            try
            {
                var response = await _settingsService.GetLanguages();

                if (response.IsSuccess)
                {
                    Languages = new ObservableCollection<LanguageModel>(response.Data);
                    SelectedLanguage = Languages.FirstOrDefault(l => l.Id == Model.LanguageId);
                    //SelectedLanguage = Model?.LanguageId == null ? Languages.FirstOrDefault() : Languages.FirstOrDefault(l => l.Id == Model.LanguageId);
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

        private async void LoadTimeZones()
        {
            if (TimeZones != null)
                return;

            try
            {
                var response = await _settingsService.GetTimeZones();

                if (response.IsSuccess)
                {
                    TimeZones = new ObservableCollection<TimeZoneModel>(response.Data);
                    SelectedTimeZone = TimeZones.FirstOrDefault(t => t.Id == Model.TimeZoneId);
                    //SelectedTimeZone = Model?.TimeZoneId == null ? TimeZones.FirstOrDefault() : TimeZones.FirstOrDefault(t => t.Id == Model.TimeZoneId);
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

        private async Task OnNotifications()
        {
            await _navigation.NavigateAsync("NotificationsPage");
            //await _navigation.NavigateAsync("PushNotificationsPage");
        }

        private async Task OnLanguages()
        {
            await Task.Run(() =>
            {
                SetFocusLanguage = true;
            });
        }

        private async Task OnTimeZone()
        {
            await Task.Run(() =>
            {
                SetFocusTimeZone = true;
            });
        }

        private async Task OnSave()
        {
            try
            {
                if (string.IsNullOrEmpty(Model.LanguageId) || string.IsNullOrEmpty(Model.TimeZoneId))
                    return;

                IsBusy = true;
                BusyMessage = "Please wait..";
                var response = await _settingsService.UpdateSettings(Model);
                if (response.IsSuccess)
                {
                    App.UserProfileInfo = response.Data;
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
