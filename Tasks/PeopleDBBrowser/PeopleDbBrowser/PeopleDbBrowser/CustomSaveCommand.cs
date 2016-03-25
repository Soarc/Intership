using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace Internship.PeopleDbBrowser
{
    public class CustomSaveCommand : ICommand
    {
        Action _action;
        Predicate<object> _canExecute;

        public CustomSaveCommand(Action action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }


        }

        public bool CanExecute(object parameter)
        {
            bool t = _canExecute == null ? true : _canExecute(parameter);
            return t;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
