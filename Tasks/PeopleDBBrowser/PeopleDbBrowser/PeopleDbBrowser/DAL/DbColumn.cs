using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.DAL
{
     class DbColumn
    {
        public string Name { get; set; }
        public string Type { get; set; }
       
        public bool IsPrimary { get; set; }
        public bool IsNull { get; set; }
        public bool isIdentity { get; set; }
    }
}
