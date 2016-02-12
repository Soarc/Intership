using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    public class User
    {
        public string DisplayName { get; set; }
        public int Id { get; set; }
        public ConnectionInfo ConnectionDetail { get; set; }

        public void Send(Message msg)
        {

        }

    }
}
