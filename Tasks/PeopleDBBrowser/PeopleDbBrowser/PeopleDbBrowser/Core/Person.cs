using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.Core
{
    class Person
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Patron { get; set; }
            public DateTime Birthday { get; set; }
            public Address Address { get; set; }
        
    }
}
