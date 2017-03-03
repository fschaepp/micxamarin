using System.Collections.Generic;

namespace MediaLib.App.Command
{
    internal class CommandManger
    {
        private static readonly List<IDelegateCommand> commands = new List<IDelegateCommand>();

        public static void Register(IDelegateCommand command)
        {
            if (commands.Contains(command))
            {
                return;
            }
            commands.Add(command);
        }

        public static void Remove(IDelegateCommand command)
        {
            commands.Remove(command);
        }

        public static void RaiseCanExecuteChanged()
        {
            foreach (var delegateCommand in commands)
            {
                delegateCommand.RaiseCanExecuteChanged();
            }
        }
    }
}
