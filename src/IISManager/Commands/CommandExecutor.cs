using System;
using System.Windows.Input;

namespace IISManager.Commands
{
    public class CommandExecutor : ICommand
    {
        private Action _action;
        
        public event EventHandler CanExecuteChanged;

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
