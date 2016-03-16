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
            string path = "ConnectionString.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
            }

            //StreamReader strReader = new StreamReader(path);
            string connsctionString = "Data Source *** " + Datasource + "\n Initial Catalog *** " + Initialcatalogue + "\n Integrated Security *** " + IntegratedSecurity +
            "\n User ID *** " + Login + "\n Password ***" + Password + "\n";
            File.AppendAllText(path, connsctionString+ "\n");
        }

        public void Load()
        {
            string[] lines = File.ReadAllLines(@"ConnectionString.txt");
            string[] linesWithoutAsterics = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int astericsIndex = lines[i].IndexOf('*');
                linesWithoutAsterics[i] = lines[i].Substring(lines[i][0], lines[i][astericsIndex]) + "=" +lines[i].Substring(lines[i][astericsIndex] + 4);

                ConnectionString += linesWithoutAsterics[i]; 

            }
        }
    }
}
