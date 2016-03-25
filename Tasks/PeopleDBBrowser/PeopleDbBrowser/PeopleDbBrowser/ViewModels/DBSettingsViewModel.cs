using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Internship.PeopleDbBrowser.Core;


namespace Internship.PeopleDbBrowser.ViewModels
{
    public class DBSettingsViewModel : ViewModelBase
    {
        private string _serverName;
        private string _dbName;
        private string _userId;
        private string _password;

        private bool _isSQLChecked;

        private DbSettings _dbSettings;

        public ICommand SaveCommand { get; set; }

        public DBSettingsViewModel()
        {
            _dbSettings = new DbSettings();
            _dbSettings.Load();
            SaveCommand = new CustomSaveCommand(Save, CanSave);
        }

        private bool CanSave(object obj)
        {
           
            if (string.IsNullOrWhiteSpace(_serverName) || string.IsNullOrWhiteSpace(_dbName))
                return false;

            if (IsSQLChecked)
            {
                if (string.IsNullOrWhiteSpace(_userId) || string.IsNullOrWhiteSpace(_password))
                    return false;
            }

            return true;

        }

        private void Save()
        {
            if (AnyPropertyChanged)
                _dbSettings.Save();
        }


        public bool IsSQLChecked
        {
            get { return _isSQLChecked; }
            set
            {
                _isSQLChecked = value;

                RaisePropertyChanged(nameof(IsSQLChecked));
            }
        }

        public string ServerName
        {
            get { return _serverName; }
            set
            {
                _serverName = value;

                RaisePropertyChanged(nameof(ServerName));
            }
        }

        public string DBName
        {
            get { return _dbName; }
            set
            {
                _dbName = value;

                RaisePropertyChanged(nameof(DBName));

            }
        }




        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged(nameof(UserId));
            }
        }



        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

    }
}
