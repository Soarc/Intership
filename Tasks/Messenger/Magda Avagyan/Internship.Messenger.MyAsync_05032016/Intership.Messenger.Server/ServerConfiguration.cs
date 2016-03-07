using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Messenger.Server
{
    class ServerConfiguration
    {
        public int Port { get; set; }

        public int MaxClients { get; set; }

        public ServerConfiguration()
        {
            this.Port = 1300;
            this.MaxClients = 10;
        }

    }
}
