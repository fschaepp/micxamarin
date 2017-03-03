namespace MediaLib.App.ViewModel
{
    internal abstract class PageViewModel : BaseViewModel, IPageViewModel
    {
        private string _title;

        public virtual void OnNavigatedTo(params object[] parameters)
        {
            
        }

        public virtual void OnNavigatedFrom()
        {
            
        }

        public abstract string Title { get; }
    }
}
