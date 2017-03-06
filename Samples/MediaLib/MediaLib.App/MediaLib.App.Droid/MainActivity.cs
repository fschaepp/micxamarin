using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Mobile;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;

namespace MediaLib.App.Droid
{
    [Activity(Label = "MediaLib.App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private StandardKernel _container = null;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            MobileCenter.Configure("9792bb02-e502-402b-8bf9-0c5724b73f24");

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CreateKernel();
            var app = new App(_container);
            LoadApplication(app);
        }

        private void CreateKernel()
        {
            _container = new StandardKernel();
        }
    }
}