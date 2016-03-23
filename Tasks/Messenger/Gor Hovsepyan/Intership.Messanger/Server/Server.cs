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
    public enum ServerActions
    {
        ClientId,
        NewClientConnected,
        ClientDisconnected
    }
   public  class Server
    {
        TcpListener _listener;

        List<User> _users;

        int _currentClientId;





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

          
                while (true)
                {
                    var tcpclient = _listener.AcceptTcpClient();
                    var newClient = new User(tcpclient);
                    HandleClient(newClient);
                }
            
           


        }

        async void HandleClient(User newClient)
        {



            _users.Add(newClient);



            newClient.ClientId = ++_currentClientId;

            await newClient.StartSend();


            Message newMessage = new Message();
            newMessage.ClientId = 0;
            newMessage.MessageText = $"ACTION={ServerActions.ClientId};CLIENTID={newClient.ClientId}";
            newClient.SendMessage(newMessage);
  


            foreach (var client in _users)
            {
                if (client == newClient)
                    continue;
                newMessage = new Message();
                newMessage.ClientId = 0;
                newMessage.MessageText = $"ACTION={ServerActions.NewClientConnected};NEWCLIENTID={client.ClientId};NICKNAME={client.Nickname}";
                newClient.SendMessage(newMessage);


            }


            newClient.MessageReceived += OnMessageReceived;

            await newClient.StartReceived();

        }


        void OnMessageReceived(User client, Message message)
        {
            if (!client.NicknameReceived)
            {
                client.Nickname = message.MessageText;
                client.NicknameReceived = true;
                Broadcast(new Message
                {
                    ClientId = 0,
                    
                    MessageText = $"ACTION={ServerActions.ClientId};NEWCLIENTID={client.ClientId};NICKNAME={client.Nickname}"
                });
                
                return;

            }
        }
        
        void Broadcast(Message mess)
        {
            foreach (var client in _users)
            {
                client.SendMessage(mess);
            }
        }

        public void Stop()
        {

        }

    }
    

   

}
