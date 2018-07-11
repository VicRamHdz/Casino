using Prism.Unity;
using Xamarin.Forms;
using Cheeteye.Views;
using FFImageLoading.Svg.Forms;
using Cheeteye.Models;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Cheeteye
{
	public partial class App : PrismApplication
	{
		public App() : this(null) { }

		public static UserProfileInfoModel UserProfileInfo { get; set; }

		protected override void OnInitialized()
		{
			InitializeComponent();
			var ignore = new SvgCachedImage();

#if DEBUG
			UserProfileInfo = new UserProfileInfoModel()
			{
				UserProfileId = "71b7c6e3-750e-4dac-8cdc-c2b159b480a0",
				FirstName = "Victor",
				LastName = "Ramos",
				Email = "scrbboy@gmail.com"
			};
			NavigationService.NavigateAsync("HomePage");
#else
            NavigationService.NavigateAsync("LandingPage");
#endif
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<LandingPage>();
			Container.RegisterTypeForNavigation<LoginPage>();
			Container.RegisterTypeForNavigation<ForgotPasswordPage>();
			Container.RegisterTypeForNavigation<HomePage>();
			Container.RegisterTypeForNavigation<MembershipPage>();
			Container.RegisterTypeForNavigation<OTPPage>();
			Container.RegisterTypeForNavigation<CreatePasswordPage>();
			Container.RegisterTypeForNavigation<ProfileDetailsPage>();
			Container.RegisterTypeForNavigation<SettingsPage>();
			Container.RegisterTypeForNavigation<NotificationsPage>();
			Container.RegisterTypeForNavigation<PushNotificationsPage>();
			Container.RegisterTypeForNavigation<EventDetailsPage>();
			Container.RegisterTypeForNavigation<ChallengeDetailsPage>();
		}

		public App(IPlatformInitializer plataInitializer = null) : base(plataInitializer)
		{

		}
	}
}
