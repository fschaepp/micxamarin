﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MediaLib.App.Command;
using MediaLib.App.Common.Interface;
using MediaLib.App.Common.Model;
using MediaLib.App.Navigation;

namespace MediaLib.App.ViewModel
{
    internal class AllMediaViewModel : PageViewModel
    {
        private readonly IMediaRepository _mediaRepository;
        private Media _selectedMedia;
        private IDelegateCommand _addMediaCommand;
        private IDelegateCommand _editMediaCommand;
        private ICommand _deleteMediaCommand;
        public ObservableCollection<Media> AllMedia { get; private set; }

        public Media SelectedMedia
        {
            get { return _selectedMedia; }
            set
            {
                if (_selectedMedia == value)
                {
                    return;
                }
                _selectedMedia = value;
                OnPropertyChanged();
                CommandManger.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddMediaCommand
        {
            get { return _addMediaCommand ?? (_addMediaCommand = new DelegateCommand(OnExecuteAddMedia)); }
        }

        private void OnExecuteAddMedia()
        {
            // TODO: Navigate to Add Media Page
        }

        public ICommand EditMediaCommand
        {
            get { return _editMediaCommand ?? (_editMediaCommand = new DelegateCommand(OnExecuteEditMedia, () => SelectedMedia != null)); }
        }

        private void OnExecuteEditMedia()
        {
            NavigationService.Navigate<EditMediaViewModel>(SelectedMedia);
        }

        public ICommand DeleteMediaCommand
        {
            get { return _deleteMediaCommand ?? (_deleteMediaCommand = new DelegateCommand(OnExecuteDeleteMedia, () => SelectedMedia != null)); }
        }

        public INavigationService NavigationService { get; set; }

        private void OnExecuteDeleteMedia()
        {
            _mediaRepository.Delete(SelectedMedia);
            AllMedia.Remove(SelectedMedia);
            SelectedMedia = null;
        }

        public AllMediaViewModel(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
            LoadMedia();
        }

        private void LoadMedia()
        {
            var media = _mediaRepository.Get();
            AllMedia = new ObservableCollection<Media>(media);
            OnPropertyChanged(nameof(AllMedia));
        }

        public override string Title => "Alle Medien";
    }
}
