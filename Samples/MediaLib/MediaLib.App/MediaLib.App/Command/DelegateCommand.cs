using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaLib.App.Command
{
    public class DelegateCommand<T> : IDelegateCommand<T>
    {
        private readonly Func<T, bool> _onCanExecute;
        private readonly Action<T> _onExecute;

        public DelegateCommand(Action<T> onExecute, Func<T, bool> onCanExecute = null)
        {
            _onExecute = onExecute ?? (o => { });
            _onCanExecute = onCanExecute ?? (o => true);
            CommandManger.Register(this);
        }

        bool ICommand.CanExecute(object parameter)
        {
            try
            {
                CanExecute((T) parameter);
            }
            catch { }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            try
            {
                Execute((T) parameter);
            }
            catch { }
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(T parameter)
        {
            if (CanExecute(parameter))
            {
                _onExecute(parameter);
            }
        }

        public bool CanExecute(T parameter)
        {
            return _onCanExecute(parameter);
        }
    }

    public class DelegateCommand : IDelegateCommand
    {
        private readonly Func<bool> _canExecuteFunc;
        private readonly Action _commandAction;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action commandAction, Func<bool> canExecuteFunc = null)
        {
            _commandAction = commandAction ?? (() => { });
            _canExecuteFunc = canExecuteFunc ?? (() => true);
            CommandManger.Register(this);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc();
        }

        public void Execute(object parameter)
        {
            if (_canExecuteFunc())
            {
                _commandAction();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class AsyncDelegateCommand : IDelegateCommand
    {
        private readonly Func<bool> _canExecuteFunc;
        private readonly Func<Task> _commandAction;
        public event EventHandler CanExecuteChanged;

        public AsyncDelegateCommand(Func<Task> commandAction, Func<bool> canExecuteFunc = null)
        {
            _commandAction = commandAction ?? (() => null);
            _canExecuteFunc = canExecuteFunc ?? (() => true);
            CommandManger.Register(this);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                Task.Run(async () => await _commandAction());
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public interface IDelegateCommand<in T> : IDelegateCommand
    {
        void Execute(T parameter);

        bool CanExecute(T parameter);
    }

    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
