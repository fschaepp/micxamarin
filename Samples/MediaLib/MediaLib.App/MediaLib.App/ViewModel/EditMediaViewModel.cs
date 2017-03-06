using System.Linq;
using System.Windows.Input;
using MediaLib.App.Command;
using MediaLib.App.Common.Interface;
using MediaLib.App.Common.Model;
using MediaLib.App.Navigation;

namespace MediaLib.App.ViewModel
{
    internal class EditMediaViewModel : PageViewModel
    {
        private readonly IMediaRepository _mediaRepository;
        private IDelegateCommand _saveMediaCommand;
        public Media Media { get; set; }

        public EditMediaViewModel(INavigationService navigationService, IMediaRepository mediaRepository)
            : base(navigationService)
        {
            _mediaRepository = mediaRepository;
        }

        public ICommand SaveMediaCommand
        {
            get { return _saveMediaCommand ?? (_saveMediaCommand = new DelegateCommand(OnExecuteSaveMedia)); }
        }

        private void OnExecuteSaveMedia()
        {
            _mediaRepository.Update(Media);
            NavigationService.Back();
        }

        public override void OnNavigatedTo(PageNavigationDirection direction, params object[] parameters)
        {
            base.OnNavigatedTo(direction, parameters);
            if (direction == PageNavigationDirection.Forward && (parameters?.Any() ?? false))
            {
                Media = parameters.OfType<Media>().FirstOrDefault();
                OnPropertyChanged(nameof(Media));
            }
        }

        public override string Title => Media.Title;
    }
}
