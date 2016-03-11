using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.Core
{
    class DbSettings
    {
        public string Datasource { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Initialcatalogue { get; set; }


        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}
