using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Cheeteye.Models;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
	public class ChallengeDetailsPageViewModel : BaseViewModel
	{
		public ICommand BackCommand { get; set; }

		public ICommand CheckInCommand { get; set; }

		private ChallengesModel _Challenge;
		public ChallengesModel Challenge { get { return _Challenge; } set { SetProperty(ref _Challenge, value); } }

		public ChallengeDetailsPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
		{
			_navigation = navigationService;
			_dialogService = dialogService;
			//Title = "FREQUENT ROLLER";
			BackCommand = new Command(async () => { await OnBack(); });
			CheckInCommand = new Command(async () => { await OnBack(); });
		}

		public override void OnNavigatedTo(NavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			if (parameters.ContainsKey("challenge"))
			{
				Challenge = (ChallengesModel)parameters["challenge"];
				Title = Challenge.Name;
			}
		}

		private async Task OnBack()
		{
			await _navigation.GoBackAsync();
		}
	}
}
