using System;
namespace Cheeteye
{
	public class Constants
	{
		public static string BaseApiUrl { get; internal set; } = "https://reveye-backend.azurewebsites.net/api/";
		public static string HockeyAndroidAPPKey { get; set; } = "652de92f975346deb611eb0961ac2bfc";
		public static string HockeyiOSAPPKey { get; set; } = "9a2db28b9ad44c8a83df86df8dee2bad";
		public static string HockeyAndroidAppUrl = string.Format("https://rink.hockeyapp.net/api/2/apps/{0}/", HockeyAndroidAPPKey);
		public static string HockeyIOSAppUrl = string.Format("https://rink.hockeyapp.net/api/2/apps/{0}/", HockeyiOSAPPKey);
	}
}
