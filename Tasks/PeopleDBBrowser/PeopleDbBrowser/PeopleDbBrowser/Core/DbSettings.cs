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

        public string ConnectionString { get; set; }

        public void Save()
        {
            string path = "ConnectionStringInfo.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
            }
            else
            {
                System.IO.File.WriteAllText(path, string.Empty);
            }

            //StreamReader strReader = new StreamReader(path);
            string fileContent = "Data Source *** " + Datasource + "\nInitial Catalog *** " + Initialcatalogue + "\nIntegrated Security *** " + IntegratedSecurity +
            "\nUser ID *** " + Login + "\nPassword *** " + Password + "\n";
            File.AppendAllText(path, fileContent + "\n");
        }

        public void Load()
        {
            string[] lines = File.ReadAllLines(@"ConnectionString.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Data Source *** ") == true)
                {
                    Datasource = lines[i].Substring(lines[i].LastIndexOf("Data Source *** "), lines[i].Length - lines[i].LastIndexOf("Data Source ***"));

                }
                if (lines[i].StartsWith("Initial Catalog *** ") == true)
                {
                    Initialcatalogue = lines[i].Substring(lines[i].LastIndexOf("Initial Catalog *** "), lines[i].Length - lines[i].LastIndexOf("Initial Catalog *** "));

                }
                if (lines[i].StartsWith("Integrated Security *** ") == true)
                {
                    IntegratedSecurity = Convert.ToBoolean(lines[i].Substring(lines[i].LastIndexOf("Integrated Security *** "), lines[i].Length - lines[i].LastIndexOf("Integrated Security *** ")));

            }
                if (lines[i].StartsWith("User ID *** ") == true)
                {
                    Login = lines[i].Substring(lines[i].LastIndexOf("User ID *** "), lines[i].Length - lines[i].LastIndexOf("User ID *** "));
                }
                if (lines[i].StartsWith("Password *** ") == true)
                {
                    Password = lines[i].Substring(lines[i].LastIndexOf("Password *** "), lines[i].Length - lines[i].LastIndexOf("Password *** "));
                }
            }
            string[] linesWithoutAsterics = new string[lines.Length];
        }
    }
}
