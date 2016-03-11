using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intership.Messenger.Server
{
    class Server
    {
        TcpListener _listener;
        List<Client> _clients;

        public ServerConfiguration Config
        {
            get; private set;
        }



        public Server()
        {
            Config = new ServerConfiguration();
            _clients = new List<Client>();
        }

        public void Start()
        { 
            _listener = new TcpListener(IPAddress.Any, Config.Port);
            _listener.Start();

            while (true)
            {
                var tcpClient = _listener.AcceptTcpClient();
                var newClient = new Client(tcpClient);
                HandleClient(newClient);
            }
        

            

        }

        void HandleClient(Client newClient)
        {
            

            _clients.Add(newClient);

       

            var sendThread = new Thread(newClient.StartSend);
            sendThread.Start();

            var receiveThread = new Thread(newClient.StartReceive);
            receiveThread.Start();
           
        }

        public void Stop()
        {
        }
    }
}
