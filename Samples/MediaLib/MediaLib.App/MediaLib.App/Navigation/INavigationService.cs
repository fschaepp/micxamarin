using MediaLib.App.ViewModel;

namespace MediaLib.App.Navigation
{
    internal interface INavigationService
    {
        void Navigate<T>(params object[] parameters) where T : IPageViewModel;

        void Back();
    }
}
