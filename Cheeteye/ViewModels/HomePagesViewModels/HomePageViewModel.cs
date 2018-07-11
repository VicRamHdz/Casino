using System;
using System.Collections.Generic;
using Cheeteye.Controls;
using Cheeteye.Views;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace Cheeteye.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public List<TabItemPage> Pages { get; set; }

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigation = navigationService;
            _dialogService = dialogService;
            Pages = new List<TabItemPage>()
            {
                new TabItemPage
                {
                    Title = "CHALLENGES",
                    IconName = "uiNavDefaultChallenges.png",
                    IconActiveName = "uiNavActiveChallenges.png",
                    Content = Activator.CreateInstance(typeof(ChallengesContentView), new ChallengesContentViewModel(navigationService, dialogService)) as ContentView,
                },
                new TabItemPage
                {
                    Title = "POINTS",
                    IconName = "uiNavDefaultPoints.png",
                    IconActiveName = "uiNavActivePoints.png",
                    Content = Activator.CreateInstance(typeof(SpecialsContentView), new SpecialsContentViewModel(navigationService, dialogService)) as ContentView,
                },
                new TabItemPage
                {
                    Title = "REWARDS",
                    IconName = "uiNavDefaultRewards.png",
                    IconActiveName = "uiNavActiveRewards.png",
                    Content = Activator.CreateInstance(typeof(RewardsContentView), new RewardsContentViewModel(navigationService, dialogService)) as ContentView,
                },
                new TabItemPage
                {
                    Title = "EVENTS",
                    IconName = "uiNavDefaultEvents.png",
                    IconActiveName = "uiNavActiveEvents.png",
                    Content = Activator.CreateInstance(typeof(EventsContentView), new EventsContentViewModel(navigationService, dialogService)) as ContentView,
                },
                new TabItemPage
                {
                    Title = "PROFILE",
                    IconName = Device.RuntimePlatform == Device.iOS ? "uiNavDefaultProfile.svg" : "uiNavDefaultProfile.png",
                    IconActiveName = Device.RuntimePlatform == Device.iOS ? "uiNavActiveProfile.svg" : "uiNavActiveProfile.png",
                    Content = Activator.CreateInstance(typeof(ProfileContentView), new ProfileContentViewModel(navigationService, dialogService)) as ContentView,
                },
            };
        }
    }
}
