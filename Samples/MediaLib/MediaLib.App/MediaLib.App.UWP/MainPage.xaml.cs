using Ninject;

namespace MediaLib.App.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new MediaLib.App.App(new StandardKernel()));
        }
    }
}
