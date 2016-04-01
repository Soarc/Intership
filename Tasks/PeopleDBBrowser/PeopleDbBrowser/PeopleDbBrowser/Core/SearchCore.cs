using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship.PeopleDbBrowser.DAL;
using Internship.PeopleDbBrowser.ViewModels;
using System.Data;

namespace Internship.PeopleDbBrowser.Core
{
    class SearchCore
    {
        public  List<string> _getRegionCities;
        private List<AddressUnit> _regions;
        DbManager manager;
        SearchViewModel searchmodel;
        private List<string> _getCities;
        private List<string> _getcitystreets;
        private List<string> _getstreethouse;
        private List<string> _getRegionbycity;
        private List<string> _getStreetbyDistrict;

        public SearchCore()
        {
            _getRegionCities = new List<string>();
            _getRegionCities.Add("CityId");
            _getCities = new List<string>();
            _getCities.Add("City");
            _getcitystreets = new List<string>();
            _getcitystreets.Add("StreetId");
            _getstreethouse = new List<string>();
            _getstreethouse.Add("HouseId");
            _getRegionbycity = new List<string>();
            _getRegionbycity.Add("CityId");
            _getStreetbyDistrict = new List<string>();
            _getStreetbyDistrict.Add("CommunityId");

            manager = new DbManager();
            searchmodel = new SearchViewModel();
            _regions = new List<AddressUnit>();
            _regions.Add(new AddressUnit { Id = 1, Name = "Շիրակ" });
            _regions.Add(new AddressUnit { Id = 2, Name = "Երևան" });
            _regions.Add(new AddressUnit { Id = 3, Name = "Արմավիր" });
            _regions.Add(new AddressUnit { Id = 4, Name = "Արարատ" });
            _regions.Add(new AddressUnit { Id = 5, Name = "Լոռի" });
            _regions.Add(new AddressUnit { Id = 6, Name = "Գեղարքունիք" });
            _regions.Add(new AddressUnit { Id = 7, Name = "Վայոց Ձոր" });
            _regions.Add(new AddressUnit { Id = 8, Name = "Սյունիք" });
            _regions.Add(new AddressUnit { Id = 9, Name = "Կոտայք" });
            _regions.Add(new AddressUnit { Id = 10, Name = "Արագածոտն" });
            _regions.Add(new AddressUnit { Id = 11, Name = "Տավուշ" });
        }

        private AddressUnit GetDistrictStreet(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["AddressId"],
                Name = (string)data["CommunityId"]

            };
            return addressunit;
        }
        private AddressUnit GetregCity(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["AddressId"],
                Name = (string)data["CityId"]
            
            };
            return addressunit;
        }
        private AddressUnit GetCity(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["CityId"],
                Name = (string)data["City"]

            };
            return addressunit;
        }
        private AddressUnit GetCityStreet(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["AddressId"],
                Name = (string)data["StreetId"]

            };
            return addressunit;
        }
        private AddressUnit GetstreetHouse(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["AddressId"],
                Name = (string)data["HouseId"]

            };
            return addressunit;
        }
        private AddressUnit GetRegionByCity(IDataRecord data)
        {
            var addressunit = new AddressUnit
            {
                Id = (int)data["AddressId"],
                Name = (string)data["CityId"]

            };
            return addressunit;
        }



        public List<AddressUnit> GetRegions()
        {
            return _regions;
        }

        public List<AddressUnit> GetRegionCities(int id)
        {
            id = searchmodel.SelectedRegion.Id;
            string cond = $"RegionId={id}";
            var data = manager.ExecuteQuery("Cities", _getRegionCities, cond).Select(x => GetregCity(x)).ToList();
            return data;
        }
        public List<AddressUnit> GetAllCities()
        {
            string cond = null;
            var data = manager.ExecuteQuery("Cities", _getCities, cond).Select(x => GetCity(x)).ToList();
            return data;
        }
        public List<AddressUnit> GetCityStreets(int id)
        {
            id = searchmodel.SelectedCity.Id;
            string cond = $"CityId={id}";
            var data = manager.ExecuteQuery("Streets", _getcitystreets, cond).Select(x => GetregCity(x)).ToList();
            return data;
        }
        public List<AddressUnit> GetStreetHouses(int id)
        {
            id = searchmodel.SelectedStreet.Id;
            string cond = $"StreetId={id}";
            var data = manager.ExecuteQuery("Houses", _getstreethouse, cond).Select(x => GetstreetHouse(x)).ToList();
            return data;
        }
        public List<AddressUnit> GetRegionsByCity(int  id)
        {
            id = searchmodel.SelectedRegion.Id;
            string cond = $"CityId={id}";
            var data = manager.ExecuteQuery("Cities", _getRegionbycity, cond).Select(x => GetRegionByCity(x)).ToList();
            return data;
        }
        public List<AddressUnit> GetStreetsByDistrict(int id)
        {
            id = searchmodel.SelectedDistrict.Id;
            string cond = $"CommunityId={id}";
            var data = manager.ExecuteQuery("Addresses", _getStreetbyDistrict, cond).Select(x => GetDistrictStreet(x)).ToList();
            return data;
        }
    }

    }

