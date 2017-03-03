using MediaLib.App.DataAccess;
using MediaLib.App.Navigation;
using MediaLib.App.View;
using MediaLib.App.ViewModel;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Xamarin.Forms;

namespace MediaLib.App
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));

            var allMediaViewModel = new AllMediaViewModel(new MediaRepository());
            var initialPage = new AllMediaPage
            {
                BindingContext = allMediaViewModel
            };
            MainPage = new NavigationPage(initialPage);
            var navigation = new NavigationService(MainPage);
            allMediaViewModel.NavigationService = navigation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
