using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class OTPPageViewModel : BaseViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand VerifyCommand { get; set; }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }

        public string CodeOne { get; set; }
        public string CodeTwo { get; set; }
        public string CodeThree { get; set; }
        public string CodeFour { get; set; }

        private Color _CodeOneBorderColor;
        public Color CodeOneBorderColor { get { return _CodeOneBorderColor; } set { SetProperty(ref _CodeOneBorderColor, value); } }
        private Color _CodeTwoBorderColor;
        public Color CodeTwoBorderColor { get { return _CodeTwoBorderColor; } set { SetProperty(ref _CodeTwoBorderColor, value); } }
        private Color _CodeThreeBorderColor;
        public Color CodeThreeBorderColor { get { return _CodeThreeBorderColor; } set { SetProperty(ref _CodeThreeBorderColor, value); } }
        private Color _CodeFourBorderColor;
        public Color CodeFourBorderColor { get { return _CodeFourBorderColor; } set { SetProperty(ref _CodeFourBorderColor, value); } }

        private bool _SetFocusCodeOne;
        public bool SetFocusCodeOne { get { return _SetFocusCodeOne; } set { SetProperty(ref _SetFocusCodeOne, value); } }
        private bool _SetFocusCodeTwo;
        public bool SetFocusCodeTwo { get { return _SetFocusCodeTwo; } set { SetProperty(ref _SetFocusCodeTwo, value); } }
        private bool _SetFocusCodeThree;
        public bool SetFocusCodeThree { get { return _SetFocusCodeThree; } set { SetProperty(ref _SetFocusCodeThree, value); } }
        private bool _SetFocusCodeFour;
        public bool SetFocusCodeFour { get { return _SetFocusCodeFour; } set { SetProperty(ref _SetFocusCodeFour, value); } }

        public ICommand CodeFocusCommand { get; set; }
        public ICommand CodeUnFocusCommand { get; set; }

        public ICommand CodeOneTextChangedCommand { get; set; }
        public ICommand CodeTwoTextChangedCommand { get; set; }
        public ICommand CodeThreeTextChangedCommand { get; set; }

        private MembershipModel _Model;
        public MembershipModel Model
        {
            get { return _Model; }
            set
            {
                SetProperty(ref _Model, value);
            }
        }

        public OTPPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Title = "REGISTER";
            Model = new MembershipModel();
            BackCommand = new Command(async () => { await OnBack(); });
            VerifyCommand = new Command(async () => { await OnVerify(); });

            CodeOneBorderColor = CodeTwoBorderColor = CodeThreeBorderColor = CodeFourBorderColor = (Color)Application.Current.Resources["OutlineColor"];
            CodeFocusCommand = new Command((p) => { OnCodeFocus(int.Parse(p.ToString())); });
            CodeUnFocusCommand = new Command((p) => { OnCodeUnFocus(int.Parse(p.ToString())); });
            CodeOneTextChangedCommand = new Command(() => OnCodeTextChanged(1));
            CodeTwoTextChangedCommand = new Command(() => OnCodeTextChanged(2));
            CodeThreeTextChangedCommand = new Command(() => OnCodeTextChanged(3));
        }

        private void OnCodeFocus(int CodeNumber)
        {
            if (CodeNumber == 1)
            {
                CodeOneBorderColor = (Color)Application.Current.Resources["LightTextColor"];
            }
            else if (CodeNumber == 2)
            {
                CodeTwoBorderColor = (Color)Application.Current.Resources["LightTextColor"];
            }
            else if (CodeNumber == 3)
            {
                CodeThreeBorderColor = (Color)Application.Current.Resources["LightTextColor"];
            }
            else if (CodeNumber == 4)
            {
                CodeFourBorderColor = (Color)Application.Current.Resources["LightTextColor"];
            }
        }

        private void OnCodeUnFocus(int CodeNumber)
        {
            if (CodeNumber == 1)
            {
                CodeOneBorderColor = (Color)Application.Current.Resources["OutlineColor"];
            }
            else if (CodeNumber == 2)
            {
                CodeTwoBorderColor = (Color)Application.Current.Resources["OutlineColor"];
            }
            else if (CodeNumber == 3)
            {
                CodeThreeBorderColor = (Color)Application.Current.Resources["OutlineColor"];
            }
            else if (CodeNumber == 4)
            {
                CodeFourBorderColor = (Color)Application.Current.Resources["OutlineColor"];
            }
        }

        private void OnCodeTextChanged(int CodeNumber)
        {
            if (CodeNumber == 1 && CodeOne?.Length >= 1)
            {
                SetFocusCodeTwo = true;
            }
            else if (CodeNumber == 2)
            {
                if (CodeTwo?.Length >= 1)
                    SetFocusCodeThree = true;
                else
                    SetFocusCodeOne = true;
            }
            else if (CodeNumber == 3 && CodeThree?.Length >= 1)
            {
                SetFocusCodeFour = true;
            }
        }

        private async Task OnBack()
        {
            await _navigation.GoBackAsync();
        }

        private async Task OnVerify()
        {
            IsBusy = true;
            try
            {
                if (!(CodeOne == Model.CodeOne
                      && CodeTwo == Model.CodeTwo
                      && CodeThree == Model.CodeThree
                      && CodeFour == Model.CodeFour))
                {
                    await DisplayMessage("Info", "Incorrect Code");
                    return;
                }
                else
                {
                    IsBusy = false;
                    var navigationParams = new NavigationParameters();
                    navigationParams.Add("MembershipInfo", Model);
                    await _navigation.NavigateAsync("CreatePasswordPage", navigationParams);
                    return;
                }
            }
            catch (System.Exception ex)
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
                Email = Model.Email;
                RaisePropertyChanged(nameof(Model));
            }
        }
    }
}
