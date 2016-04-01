using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship.PeopleDbBrowser.Core
{
    class Address
    {
        public int Id { get; set; }
        public AddressUnit City { get; set; }
        public AddressUnit Region { get; set; }
        public AddressUnit Street { get; set; }
        public AddressUnit House { get; set; }
        public AddressUnit District { get; set; }

    }
}
