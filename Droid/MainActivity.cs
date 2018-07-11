using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using FFImageLoading;
using Acr.UserDialogs;
using HockeyApp.Android;
using Prism;
using Microsoft.Practices.Unity;
using Prism.Unity;
using HockeyApp.Android.Objects;
using Plugin.Permissions;

namespace Cheeteye.Droid
{
    [Activity(Label = "Cheeteye", Icon = "@drawable/logo", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

            CachedImageRenderer.Init();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new CustomLogger(),
            };
            ImageService.Instance.Initialize(config);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            // Initilize ACR User Dialogs
            UserDialogs.Init(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            CrashManager.Register(this, Constants.HockeyAndroidAPPKey);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class AndroidPlatformInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IUnityContainer container)
            {

            }
        }

        public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
        {
            public void Debug(string message)
            {
                Console.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                Console.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                Error(errorMessage + System.Environment.NewLine + ex.ToString());
            }
        }

        public void HearShake()
        {
            FeedbackManager.RequireUserEmail = FeedbackUserDataElement.Required;
            FeedbackManager.RequireUserName = FeedbackUserDataElement.Required;

            FeedbackManager.SetActivityForScreenshot(this);
            FeedbackManager.TakeScreenshot(this);
            FeedbackManager.ShowFeedbackActivity(this);
        }

        public class CheeteyeCrashManagerListener : CrashManagerListener
        {
            /// <summary>
            /// Shoulds the automatic upload crashes.
            /// </summary>
            /// <returns></returns>
            public override bool ShouldAutoUploadCrashes()
            {
                return true;
            }
        }
    }
}
