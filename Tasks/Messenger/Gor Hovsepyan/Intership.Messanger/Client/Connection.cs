
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MessangerClient
{

    public class ServerConnection
    {
        Queue<Message> messages;
        public List<User> Users { get; private set; }
        byte[] _messageLength;
        TcpClient _client;

        int _clientId;

        public ServerConnection()
        {
            Users = new List<User>();
            messages = new Queue<Message>();
            _messageLength = new byte[sizeof(int)];
        }
        public async void Connect(string Ip, int Port, string nick)
        {
            _client = new TcpClient();
            _client.Connect(Ip, Port);


            await StartSend();
            await StartReceived();

            SendMessage(nick);

        }



        public void SendMessage(string message)
        {
            messages.Enqueue(new Message
            {
                ClientId = this._clientId,
                MessageText = message,
                Timestamp = DateTime.Now
            });



        }
        public Task StartSend()
        {
            while (true)
            {
                if (messages.Count == 0)
                    continue;

                var message = messages.Dequeue();
                var stream = _client.GetStream();
                var data = message.GetBytes();


                var messagelengthbytes = BitConverter.GetBytes(data.Length);
                stream.Write(messagelengthbytes, 0, messagelengthbytes.Length);
                stream.Write(data, 0, data.Length);

            }

        }

        public Task StartReceived()
        {
            while (true)
            {
                var stream = _client.GetStream();
                stream.Read(_messageLength, 0, _messageLength.Length);

                var data = new byte[BitConverter.ToInt32(_messageLength, 0)];
                stream.Read(data, 0, data.Length);

                var message = new Message();
                message.ReadBytes(data);

                if (message.ClientId == 0)
                {
                    ProccesServerMessage(message);
                }
                else
                {
                    ProccesClientMessage(message);
                }

                if (MessageReceived != null)
                {
                    var thread = new Thread(() => MessageReceived(message));
                    thread.Start();
                }

            }
        }

        private void ProccesClientMessage(Message message)
        {
            if (MessageReceived != null)
                MessageReceived(message);
        }

        private void ProccesServerMessage(Message message)
        {
            var messageVariables = message.MessageText.Split(';');
            if (messageVariables.Length >= 2)
            {
                var vareb = messageVariables.Select(x =>
                 {

                     var parts = x.Split('=');
                     var variable = parts[0];
                     var value = parts[1];
                     return new { Variable = variable, Value = value };
                 }).ToArray();

                //if(!isFirstmessage)
                // {
                //     clientId = Convert.ToInt32(vareb[0].Value);
                //     isFirstmessage = true;
                //     return;
                // }
                var act = vareb.FirstOrDefault(x => x.Variable.Contains("ACTION"));
                if (act != null)
                {
                    var action = (ServerActions)Enum.Parse(typeof(ServerActions), act.Value);

                    switch (action)
                    {
                        case ServerActions.ClientId:
                            var idVariable = vareb.First(x => x.Variable == "CLIENTID");
                            _clientId = Convert.ToInt32(idVariable.Value);
                            break;
                        case ServerActions.NewClientConnected:
                            var clientId = Convert.ToInt32(vareb.First(x => x.Variable == "NEWCLIENTID").Value);
                            var nickname = vareb.First(x => x.Variable == "NICKNAME").Value;
                            var user = new User { Id = clientId, Nickname = nickname };
                            Users.Add(user);
                            if (newUserConnected != null)
                                newUserConnected(user);
                            break;
                        case ServerActions.ClientDisconnected:
                            var dclientId = Convert.ToInt32(vareb.First(x => x.Variable == "NEWCLIENTID").Value);
                            var dnickname = vareb.First(x => x.Variable == "NICKNAME").Value;
                            var duser = new User { Id = dclientId, Nickname = dnickname };
                            Users.Remove(duser);
                            if (userDisconnected != null)
                                userDisconnected(duser);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public event Action<Message> MessageReceived;

        public event Action<User> newUserConnected;

        public event Action<User> userDisconnected;



        // Connect(IP, Port)

        // Disconnect()

        //Send Message(string)

        //MessageReceived

    }

}

public enum ServerActions
{
    ClientId,
    NewClientConnected,
    ClientDisconnected
}




