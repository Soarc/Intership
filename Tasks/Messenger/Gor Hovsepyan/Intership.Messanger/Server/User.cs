using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MessangerServer
{
    public class User
    {
        TcpClient _client;
        Queue<Message> messageQueue;

        byte[] _messageLength;
        public event Action<User, Message> MessageReceived;
        public int ClientId { get; set; }
        public TcpClient Client
        {
            get
            {
                return _client;
            }


        }

        public string Nickname { get; set; }

        public bool NicknameReceived
        {
            get; set;
        }

        public User(TcpClient client)
        {
            _client = client;

            messageQueue = new Queue<Message>();
            _messageLength = new byte[sizeof(int)];

        }



        public  Task StartSend()
        {
            while (true)
            {
                if (messageQueue.Count == 0)
                {
                    continue;
                }
                else
                {
                    var message = messageQueue.Dequeue();
                    var stream = _client.GetStream();
                    var data = message.GetBytes();

                    var messagelengthbytes = BitConverter.GetBytes(data.Length);
                    stream.Write(messagelengthbytes, 0, messagelengthbytes.Length);
                    stream.Write(data, 0, data.Length);
                }

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

                if (MessageReceived != null)
                {
                    var thread = new Thread(() => MessageReceived(this, message));
                    thread.Start();
                }

            }

        }

        public void SendMessage(Message message)
        {
            this.messageQueue.Enqueue(message);
        }

        public void RecieveMessage()
        {

        }
    }


}