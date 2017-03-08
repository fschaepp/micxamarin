using System.ComponentModel;
using System.Runtime.CompilerServices;
using MediaLib.App.Command;

namespace MediaLib.App.ViewModel
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            CommandManger.RaiseCanExecuteChanged();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
