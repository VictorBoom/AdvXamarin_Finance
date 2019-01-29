using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }

        protected override async void OnStart()
        {
            string androidAppSecret = "1a29b15e-0d98-48a4-8857-b4bdb44e7cbe";
            AppCenter.Start($"android={androidAppSecret}", typeof(Crashes), typeof(Analytics), typeof(Push));

            bool didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();
            if(didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
