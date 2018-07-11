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
	public class ChallengesContentViewModel : BaseViewModel
	{
		public ICommand StarCommand { get; set; }
		private string _WelcomeMessage;
		public string WelcomeMessage
		{
			get { return _WelcomeMessage; }
			set { SetProperty(ref _WelcomeMessage, value); }
		}

		private ObservableCollection<ChallengesModel> _Challenges;
		public ObservableCollection<ChallengesModel> Challenges
		{
			get
			{
				return _Challenges;
			}
			set
			{
				SetProperty(ref _Challenges, value);
			}
		}
		public ICommand SelectEventCommand { get; set; }

		private ChallengesService _challengesService;

		public ChallengesContentViewModel(INavigationService navigationService, IPageDialogService dialogService)
		{
			_navigation = navigationService;
			_dialogService = dialogService;
			//StarCommand = new Command(async () => { await OnStar(); });
			SelectEventCommand = new Command(async (i) => { await OnSelectEvent((ChallengesModel)i); });
			WelcomeMessage = $"Welcome { App.UserProfileInfo.FirstName }";
			_challengesService = new ChallengesService();
			LoadChallenges();
		}

		private async void LoadChallenges()
		{
			if (Challenges != null)
				return;

			try
			{
				var response = await _challengesService.GetChallenges();

				if (response.IsSuccess)
				{
					Challenges = new ObservableCollection<ChallengesModel>(response.Data);
					//foreach (var item in Challenges)
					//{
					//	item.IconUrl = "https://cdn4.iconfinder.com/data/icons/casino-games-1/512/Poker-512.png";
					//	item.BannerUrl = "https://dimg04.c-ctrip.com/images/220p0g0000007r685E2EF_R_550_412.jpg";
					//}
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

		private async Task OnSelectEvent(ChallengesModel item)
		{
			var parameters = new NavigationParameters();
			parameters.Add("challenge", item);
			await _navigation.NavigateAsync("ChallengeDetailsPage", parameters);
		}

		//private async Task OnStar()
		//{
		//	await _navigation.NavigateAsync("ChallengeDetailsPage");
		//}
	}
}
