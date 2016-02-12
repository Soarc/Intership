using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData;

namespace Internship.Messenger.Server
{
    public class Server
    {

        public int Port { get; set; }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void ConnectUser(User newUser)
        {
            ConnectedUsers.AddUser(newUser);
        }

        public void DisconnectUser()
        {

        }

        public void Broadcast(string msg)
        {

        }
    }
}
