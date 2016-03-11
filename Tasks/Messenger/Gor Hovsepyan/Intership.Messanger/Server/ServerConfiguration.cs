using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerConfiguration
    {
        public int Port { get; set; }
        public int Maxclients { get; set; }

        public ServerConfiguration()
        {
            Port = 1300;
            Maxclients = 10;
        }
    }
}
