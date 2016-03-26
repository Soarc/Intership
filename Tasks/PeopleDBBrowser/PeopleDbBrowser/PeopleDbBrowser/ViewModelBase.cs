using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _anyPropertyChanged;

        public bool AnyPropertyChanged
        {
            get { return _anyPropertyChanged; }
            set { _anyPropertyChanged = value; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                AnyPropertyChanged = true;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            else
                AnyPropertyChanged = false;
        }
    }
}
