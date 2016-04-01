using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship.PeopleDbBrowser.DAL;
using System.Collections;
using System.Windows.Input;
using System.Data;
using Internship.PeopleDbBrowser.Core;

namespace Internship.PeopleDbBrowser.ViewModels
{
    class SearchViewModel : ViewModelBase
    {
        SearchCore core;
        bool _isYerevan;
        string _validlabel;
        List<Person> _data;
        DbManager db;
        public List<Person> SearchResult
        {
            get
            {
               
                return _data;
                
            }
            private set { _data = value; RaisePropertyChanged(nameof(SearchResult)); }
            
        }
        public List<string> columns;
        private string _name;
        private string _lastname;
        private string _patron;

        public bool IsYerevan
        {
            get
            {
                return _isYerevan;
            }
            set
            {
                _isYerevan = value;
                RaisePropertyChanged(nameof(IsYerevan));
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; RaisePropertyChanged(nameof(Name));
            }
        }
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value; RaisePropertyChanged(nameof(LastName));
            }
        }
        public string Patron
        {
            get
            {
                return _patron;
            }
            set
            {
                _patron = value; RaisePropertyChanged(nameof(Patron));
            }
        }
        public ICommand SearchCommand { get; private set; }
       

        private ObservableCollection<AddressUnit> _regions = new ObservableCollection<AddressUnit>();
        private ObservableCollection<AddressUnit> _cities = new ObservableCollection<AddressUnit>();
        private ObservableCollection<AddressUnit> _streets = new ObservableCollection<AddressUnit>();
        private ObservableCollection<AddressUnit> _houses = new ObservableCollection<AddressUnit>();
        private ObservableCollection<AddressUnit> _districts = new ObservableCollection<AddressUnit>();

        private AddressUnit _selectedregion = new AddressUnit();
        private AddressUnit _selectedCity = new AddressUnit();
        private AddressUnit _selectedStreet = new AddressUnit();
        private AddressUnit _selectedHouse = new AddressUnit();
        private AddressUnit _selectedDistrict = new AddressUnit();
        public SearchViewModel()
        {

            core = new SearchCore();
            SearchCommand = new RelayCommand(Search);
            db = new DbManager();
            columns = new List<string>();
            columns.Add("AddressId");
            columns.Add("Name");
            columns.Add("Surname");
            columns.Add("Patronymic");
            columns.Add("BirthDay");
        }

        public AddressUnit SelectedRegion
        {
            
            get
            {
                return _selectedregion;
            }
            set
            {
                _selectedregion = value;
                OnSelectedregionChanged();

                RaisePropertyChanged(nameof(SelectedRegion));
            }
        }
        void OnSelectedregionChanged()
        {
            if (_selectedregion == null)
            {
                var data = core.GetAllCities();
                foreach (var item in data)
                {
                    Cities.Add(item);
                }

            }
            else
            {
                var data = core.GetRegionCities(SelectedRegion.Id);
                foreach (var item in data)
                {
                    Cities.Add(item);
                }
            }
            if (_selectedregion.Id == 2)
            {
                IsYerevan = true;
            }
            else
            {
                IsYerevan = false;
            }
        }
        void OnSelectedCityChanged()
        {
            if (_selectedCity != null)
            {
                var data = core.GetCityStreets(SelectedCity.Id);
                foreach (var item in data)
                {
                    Streets.Add(item);
                }
                var rec = core.GetRegionsByCity(SelectedCity.Id);
                foreach (var item in rec)
                {
                    Regions.Add(item);
                }
            }
           
        }
        void OnSelectedDistrictChanged()
        {
            if (_selectedDistrict != null)
            {
                var data = core.GetStreetsByDistrict(SelectedDistrict.Id);
                foreach (var item in data)
                {
                    Streets.Add(item);
                }

            }

        }
        void OnSelectedStreetChanged()
        {
            if (_selectedStreet != null)
            {
                var data = core.GetStreetHouses(SelectedStreet.Id);
                foreach (var item in data)
                {
                    Houses.Add(item);
                }

            }

        }
        public AddressUnit SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set
            {
                _selectedCity = value;
                OnSelectedCityChanged();
                 RaisePropertyChanged(nameof(SelectedCity));
            }
        }
        public AddressUnit SelectedHouse
        {
            get
            {
                return _selectedregion;
            }
            set
            {
                _selectedregion = value;

                RaisePropertyChanged(nameof(SelectedHouse));
            }
        }
        public AddressUnit SelectedStreet
        {
            get
            {
                return _selectedStreet;
            }
            set
            {
                _selectedStreet = value;
                OnSelectedStreetChanged();
                RaisePropertyChanged(nameof(SelectedStreet));
            }
        }
        public AddressUnit SelectedDistrict
        {
            get
            {
                return _selectedDistrict;
            }
            set
            {
                _selectedDistrict = value;
                OnSelectedDistrictChanged();
                RaisePropertyChanged(nameof(SelectedDistrict));
            }
        }

        public ObservableCollection<AddressUnit> Regions
        {
            get
            {
                return _regions;
            }
            set
            {

                _regions = value;
                RaisePropertyChanged(nameof(Regions));
            }
        }
        public ObservableCollection<AddressUnit> Districts
        {
            get
            {
                return _districts;
            }
            set
            {
                _districts = value;
                RaisePropertyChanged(nameof(Districts));
            }
        }
        //Region SelectedRegion;
        public ObservableCollection<AddressUnit> Cities
        {
            get
            {
                return _cities;

            }
            set
            {
                _cities = value;
                RaisePropertyChanged(nameof(Cities));
            }
        }
        public ObservableCollection<AddressUnit> Houses
        {
            get
            {
                return _regions;
            }
            set
            {

                _regions = value;
                RaisePropertyChanged(nameof(Houses));
            }
        }
        public ObservableCollection<AddressUnit> Streets
        {
            get
            {
                return _regions;
            }
            set
            {

                _regions = value;
                RaisePropertyChanged(nameof(Streets));
            }
        }

        public string ValidLabel { get { return _validlabel; } private set { _validlabel = value;RaisePropertyChanged(nameof(ValidLabel)); } }

        public Address GetAddress(IDataRecord rec)
        {
            var address = new Address
            {
                Id = (int)rec["AddressId"],
                Region = (AddressUnit)rec["RegionId"],
                City = (AddressUnit)rec["CityId"],
                District = (AddressUnit)rec["CommunityId"],
                Street = (AddressUnit)rec["CommunityId"],
                House = (AddressUnit)rec["HouseId"]

            };
            return address;
            
        }


        public Person GetPerson(IDataRecord rec)
        {
            var person = new Person
            {
                Id = (int)rec["PersonId"],
                Name = (string)rec["Name"],
                LastName = (string)rec["Surname"],
                Patron = (string)rec["Patronymic"],
                Birthday = (DateTime) rec["BirthDay"],
                Address = GetAddress(rec),

            };
            return person;
        }
        public  List<Person> Search(string name,string lastname, string patron)
        { 
       
            name = Name;
            lastname = LastName;
            patron = Patron;
            string condition = $"WHERE Name = {name}, Surname = {lastname}, Patronymic = {patron}";
            var data = db.ExecuteQuery("Persons", columns, condition).Select(x=>GetPerson(x)).ToList();
            
            return data;
            
        } 
        public void Search()
        {
            if (Name != null && LastName != null)
            {
                SearchResult = Search(Name, LastName, Patron);
            }
            else
            {
                ValidLabel = $"Անուն և Ազգանուն դաշտերը լրացված չեն";
            }
        }

       

    }
  
  
   
}
