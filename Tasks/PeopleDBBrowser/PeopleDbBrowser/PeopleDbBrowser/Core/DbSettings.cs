using System;
using System.Collections.Generic;
using System.IO;
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
            string path = "ConnectionString.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
            }

            //StreamReader strReader = new StreamReader(path);
            string connsctionString = "Data Source =" + Datasource + "; Initial Catalog =" + Initialcatalogue + " ; Integrated Security =" + IntegratedSecurity +
            ";User ID =" + Login + "; Password =" + Password + ";";
            File.AppendAllText(path, connsctionString+ "\n");
        }

        public void Load()
        {
            string[] lines = File.ReadAllLines(@"ConnectionString.txt");
        }
    }
}
