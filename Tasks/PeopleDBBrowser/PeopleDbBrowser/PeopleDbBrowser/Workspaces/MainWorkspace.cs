using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.Workspaces
{
    public class MainWorkspace:ViewModelBase
    {
        string _dbName;
        string _other;      

        public string DBName
        {
            get
            {
                return _dbName;
            }
            set
            {
                _dbName = value;
                RaisePropertyChanged(nameof(DBName));
               
            }
        }

        public string OtherProp
        {
            get
            {
                return _other;
            }
            set
            {
                _other = value;
                RaisePropertyChanged(nameof(OtherProp));
            }
        }

        public IList<string> Items
        {
            get; set;
        }

        public MainWorkspace()
        {
            DBName = "Ես Աշխատում եմ";

            this.Items = new ObservableCollection<string>()
            {
                "Valod1",
                "Gvidon2",
                "Test3"
            };
        }

    


    }
}
