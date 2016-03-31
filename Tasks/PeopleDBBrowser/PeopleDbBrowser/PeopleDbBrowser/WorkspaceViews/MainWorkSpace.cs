using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.WorkspaceViews
{
    public class MainWorkSpace
    {
        public bool IsSettingsCommandChecked{ get; set; }
        public bool IsImportCommandChecked { get; set; }
        public bool IsSearchCommandChecked { get; set; }
        public RelayCommand SettingsCommand { get; set; }
        public RelayCommand ImportCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        ViewModelBase CurrentView { get; set; }

        public MainWorkSpace()
        {
            //will be added when all viewModels are added
            //SettingsCommand = new RelayCommand(() => CurrentView = new settingsViewModel());
            //SettingsCommand = new RelayCommand(() => CurrentView = new importViewModel());
            //SettingsCommand = new RelayCommand(() => CurrentView = new searchViewModel());
        }


    }
}
