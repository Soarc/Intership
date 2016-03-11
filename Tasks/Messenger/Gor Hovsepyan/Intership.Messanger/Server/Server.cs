using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Server;
using System.Threading;

namespace MessangerServer
{
    class Server
    {
        TcpListener _listener;

        List<User> _users;

        public ServerConfiguration Config
        {
            get; private set;
        }


        public Server()
        {
            Config = new ServerConfiguration();
            _users = new List<User>();
        }


        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, Config.Port);
            _listener.Start();


            while(true)
            {
                var tcpclient = _listener.AcceptTcpClient();
                var newClient = new User(tcpclient);
                HandleClient(newClient);
            }


        }

        private void HandleClient(User newclient)
        {
            _users.Add(newclient);


            var sendThread = new Thread(newclient.StartSend);
            sendThread.Start();

            var receiveThread = new Thread(newclient.StartReceived);
            receiveThread.Start();


        }

        public void Stop()
        {

        }






    }

   
}
