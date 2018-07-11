using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Cheeteye.Models;
using Cheeteye.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {
        #region Private Properties
        private string _busyMessage = "";

        private bool _isBusy;
        internal bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                try
                {
                    if (IsBusy)
                    {
                        UserDialogs.Instance.ShowLoading(BusyMessage, MaskType.Black);
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        _busyMessage = "";
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Can not display or hide Loading dialog, Error {ex.Message} Stack: {ex.StackTrace}");
                }
                RaisePropertyChanged();
            }
        }
        internal string BusyMessage
        {
            get
            {
                return _busyMessage;
            }
            set
            {
                _busyMessage = value;
                if (IsBusy)
                {
                    UserDialogs.Instance.ShowLoading(BusyMessage, MaskType.Black);
                }
            }
        }

        internal INavigationService _navigation { get; set; }
        internal IPageDialogService _dialogService { get; set; }

        private string _Title;
        public string Title { get { return _Title; } set { SetProperty(ref _Title, value); } }
        private string _RightIcon;
        public string RightIcon { get { return _RightIcon; } set { SetProperty(ref _RightIcon, value); } }
        private string _BackIcon;
        public string BackIcon { get { return _BackIcon; } set { SetProperty(ref _BackIcon, value); } }

        public CustomCrashReportService ReportService;

        #endregion Private Properties

        public BaseViewModel()
        {
            BackIcon = "uiBack.png";
            ReportService = new CustomCrashReportService();
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public async Task DisplayMessage(string title, string message)
        {
            if (IsBusy)
                IsBusy = false;
            await _dialogService?.DisplayAlertAsync(title, message, "OK");
        }

        public async Task<bool> DisplayYesNoMessage(string title, string message)
        {
            if (IsBusy)
                IsBusy = false;
            return await _dialogService?.DisplayAlertAsync(title, message, "YES", "NO");
        }

        public async Task DisplayError(Exception ex)
        {
            if (IsBusy)
                IsBusy = false;

            //Sending stack trace to hockeyapp
            await ReportService.PostReport(ex, false, "App Error", $"App Error: {ex.Message}");

            //Display general error
            await _dialogService?.DisplayAlertAsync("Error", "Something wrong occured", "OK");

            //Showing error to console
            //await _dialogService?.DisplayAlertAsync("Error", ex.Message, "OK");
            Console.WriteLine(ex.ToString());
        }

        public async Task DisplayApiMessage<T>(ResponseResult<T> response)
        {
            if (IsBusy)
                IsBusy = false;

            if (response.StatusCode == 400)
            {
                //Display business error message
                await _dialogService?.DisplayAlertAsync("Error", response.Message, "OK");
            }
            else if (response.StatusCode == 500)
            {
                //Sending api reason error to hockeyapp
                await ReportService.PostReport(new Exception(response.Message), false, "Api Error", $"API Error: {response.Message}");

                //Display general error
                await _dialogService?.DisplayAlertAsync("Error", "Something wrong occured", "OK");

                //Showing error to console
                Console.WriteLine(response.Message);
            }
        }
    }
}
