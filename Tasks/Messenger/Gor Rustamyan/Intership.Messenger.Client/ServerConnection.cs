using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intership.Messenger.Client
{
    public class ServerConnection
    {

        TcpClient _client;
        //bool _isFirstMessageReceived;
        int _clientId;

        Queue<Message> _messagesQueue;

        public List<User> ConnectedUsers { get; private set; }

        public ServerConnection()
        {
            ConnectedUsers = new List<User>();
            _messagesQueue = new Queue<Message>();
        }


        public void Connect(string serverIP, int port, string nickName)
        {
            _client = new TcpClient();
            _client.Connect(serverIP, port);

            var receiveThread = new Thread(ReceiveLoop);
            receiveThread.Start();

            var sendThread = new Thread(SendLoop);
            sendThread.Start();

            SendMessage(nickName);



         



        }


        void ReceiveLoop()
        {
            var stream=_client.GetStream();
            var messageLenghtBuffer = new byte[sizeof(int)];

            while (true)
            {
                stream.Read(messageLenghtBuffer, 0, messageLenghtBuffer.Length);
                var messageLenght = BitConverter.ToInt32(messageLenghtBuffer, 0);

                var messageBuffer = new byte[messageLenght];
                stream.Read(messageBuffer, 0, messageLenght);

                var message = new Message();
                message.ReadBytes(messageBuffer);

                if (message.ClientId == 0)
                    ProcessServerMessage(message);
                else
                    ProcessClientMessage(message);

            }

        }

       

        void SendLoop()
        {
            var stream = _client.GetStream();
            while (true)
            {
                if (_messagesQueue.Count == 0)
                    continue;

                var message = _messagesQueue.Dequeue();
                var messageBytes=message.GetBytes();

                var messageLenghtBytes = BitConverter.GetBytes(messageBytes.Length);
                stream.Write(messageLenghtBytes, 0, messageLenghtBytes.Length);
                stream.Write(messageBytes, 0, messageBytes.Length);


            }
         



        }

        void ProcessServerMessage(Message message)
        {



            //$"ACTION=ActionName;CLIENTID={client.ClientId};NICKNAME={client.Nickname}",
            var messageVariables = message.MessageText.Split(';');

            var variables = messageVariables.Select(x =>
            {

                var parts = x.Split('=');
                var variable = parts[0];
                var value = parts[1];

                return new { Variable = variable, Value = value };

            }).ToArray();


            //if (!_isFirstMessageReceived)
            //{
            //    _clientId = Convert.ToInt32(variables[0].Value);
            //    _isFirstMessageReceived = true;
            //    return;
            //}

            var actionVariable = variables.First(x => x.Variable == "ACTION");

            var action = (ServerActions)Enum.Parse(typeof(ServerActions), actionVariable.Value);




            switch (action)
            {
                case ServerActions.ClientId:
                    var idVariable = variables.First(x => x.Variable == "CLIENTID");
                    _clientId = Convert.ToInt32(idVariable.Value);
                    break;
                case ServerActions.NewClientConnected:
                    var clientId = Convert.ToInt32(variables.First(x => x.Variable == "NEWCLIENTID").Value);
                    var nickName = variables.First(x => x.Variable == "NICKNAME").Value;
                    var user = new User { UserId = clientId, UserNickname = nickName };

                    ConnectedUsers.Add(user);
                    if (NewUserConnected != null)
                        NewUserConnected(user);


                    break;
                case ServerActions.ClientDisconnected:

                    break;
                default:
                    break;
            }












        }


        void ProcessClientMessage(Message message)
        {
            if (MessageReceived != null)
                MessageReceived(message);
        }
        public void SendMessage(string message)
        {
            _messagesQueue.Enqueue(new Message { ClientId = this._clientId, MessageText = message, Timestamp = DateTime.Now });
        }

        public event Action<Message> MessageReceived;

        public event Action<User> NewUserConnected;

        public event Action<User> NewUserDisconnected;

    }


    public enum ServerActions
    {
        ClientId,
        NewClientConnected,
        ClientDisconnected

    }



}
