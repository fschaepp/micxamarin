using MediaLib.App.Command;
using MediaLib.App.Navigation;

namespace MediaLib.App.ViewModel
{
    internal abstract class PageViewModel : BaseViewModel, IPageViewModel
    {
        protected PageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedTo(PageNavigationDirection direction, params object[] parameters)
        {
            
        }

        public virtual void OnNavigatedFrom()
        {
        }

        public abstract string Title { get; }

        public INavigationService NavigationService { get; }
    }
}
