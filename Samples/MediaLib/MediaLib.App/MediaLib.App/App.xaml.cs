using MediaLib.App.Common.Interface;
using MediaLib.App.DataAccess;
using MediaLib.App.Navigation;
using MediaLib.App.View;
using MediaLib.App.ViewModel;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Ninject;
using Xamarin.Forms;

namespace MediaLib.App
{
    public partial class App
    {
        private IKernel _container;

        public App(IKernel container)
        //public App()
        {
            _container = container;

            InitializeComponent();
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));

            SetupContainerBindings();

            MainPage = new NavigationPage();
            var navigation = new NavigationService(MainPage, _container);
            _container.Bind<INavigationService>().ToConstant(navigation);
            navigation.Navigate<AllMediaViewModel>();
        }

        private void SetupContainerBindings()
        {
            _container.Bind<IKernel>().ToSelf();
            _container.Bind<IMediaRepository>().To<MediaRepository>().InSingletonScope();
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
