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

        int _currentClientId;

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



            newClient.ClientId = ++_currentClientId;

            var sendThread = new Thread(newClient.StartSend);
            sendThread.Start();

           


            newClient.SendMessage(new Message
            {
                ClientId = 0,
                MessageText = $"CLIENTID={newClient.ClientId}",
            });

            foreach (var client in _clients)
            {
                if (client == newClient)
                    continue;

                newClient.SendMessage(new Message
                {
                    ClientId = 0,
                    MessageText =$"CLIENTID={client.ClientId};NICKNAME={client.Nickname}",
                });

            }


            newClient.MessageReceived += OnMessageReceived;

            var receiveThread = new Thread(newClient.StartReceive);
            receiveThread.Start();

          

          
          
           
        }

        void OnMessageReceived(Client client, Message message)
        {
            if (!client.NicknameReceived)
            {
                client.Nickname = message.MessageText;
                client.NicknameReceived = true;
                Broadcast(new Message
                {
                    ClientId = 0,
                    MessageText = $"NEWCLIENTID={client.ClientId};NICKNAME={client.Nickname}"
                });

                
                return;

            }

            Broadcast(message);

          
            
        }

        void Broadcast(Message message)
        {
            foreach (var client in _clients)
            {
                client.SendMessage(message);
            }
        }


        public void Stop()
        {
        }
    }
}
