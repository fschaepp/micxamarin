using Ninject;

namespace MediaLib.App.Windows
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
