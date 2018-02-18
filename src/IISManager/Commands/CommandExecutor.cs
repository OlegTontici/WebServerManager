using System;
using System.Windows.Input;

namespace IISManager.Commands
{
    public class CommandExecutor : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _action;
        public CommandExecutor(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
