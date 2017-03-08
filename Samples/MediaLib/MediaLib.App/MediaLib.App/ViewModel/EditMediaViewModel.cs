using System;
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
        private Media _media;
        private EditModeBase _editMode;

        public EditMediaViewModel(INavigationService navigationService, IMediaRepository mediaRepository)
            : base(navigationService)
        {
            _mediaRepository = mediaRepository;
        }

        public ICommand SaveMediaCommand
        {
            get { return _saveMediaCommand ?? (_saveMediaCommand = new DelegateCommand(OnExecuteSaveMedia, () => !string.IsNullOrEmpty(MediaTitle))); }
        }

        public string MediaTitle
        {
            get { return _media.Title; }
            set
            {
                if (_media.Title == value)
                {
                    return;
                }
                _media.Title = value;
                OnPropertyChanged();
            }
        }

        private void OnExecuteSaveMedia()
        {
            _editMode?.SaveStrategy()(_mediaRepository, _media);
            NavigationService.Back();
        }

        public override void OnNavigatedTo(PageNavigationDirection direction, params object[] parameters)
        {
            base.OnNavigatedTo(direction, parameters);
            if (direction == PageNavigationDirection.Forward)
            {
                _editMode = EditModeProvider.GetFrom(parameters);
                _media = _editMode.Load();
                OnPropertyChanged(nameof(MediaTitle));
            }
        }

        public override string Title => _media.Title;

        private class EditModeProvider
        {
            public static EditModeBase GetFrom(params object[] parameters)
            { 
                if (parameters?.Any() ?? false)
                {
                    return new Edit(parameters);
                }
                return new Add();
            }
        }

        private abstract class EditModeBase
        {
            public abstract Action<IMediaRepository, Media> SaveStrategy();

            public abstract Media Load();
        }

        private class Edit : EditModeBase
        {
            private readonly object[] _parameters;

            public Edit(object[] parameters)
            {
                _parameters = parameters;
            }

            public override Action<IMediaRepository, Media> SaveStrategy()
            {
                return (repo, media) => repo.Update(media);
            }

            public override Media Load()
            {
                return _parameters?.OfType<Media>().FirstOrDefault();
            }
        }
        private class Add : EditModeBase
        {
            public override Action<IMediaRepository, Media> SaveStrategy()
            {
                return (repo, media) => repo.Add(media);
            }

            public override Media Load()
            {
                return new Media { Id = Guid.NewGuid() };
            }
        }
    }
}
