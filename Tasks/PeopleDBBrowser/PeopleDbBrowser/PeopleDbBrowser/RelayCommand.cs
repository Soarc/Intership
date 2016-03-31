using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Internship.PeopleDbBrowser
{
   public class RelayCommand : ICommand
    {
        Action _action;
        public RelayCommand(Action action)
        {
            this._action = action;

        }
        public void Execute(object parameter)
        {

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;

    }
}
