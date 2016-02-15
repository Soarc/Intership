using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Intership.Messenger.Server
{
    class Client
    {
        TcpClient _tcpClient;
        Queue<Message> _messageQueue;
        byte[] _messageLenght;


        public event Action<Client, Message> MessageReceived;


        public TcpClient TcpClient
        {
            get
            {
                return _tcpClient;
            }
        }

        public int ClientId { get; set; }
        public string Nickname { get; set; }

        public bool NicknameReceived
        {
            get; set;
        }

      
        public Client(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _messageQueue = new Queue<Message>();

            _messageLenght = new byte[sizeof(int)];

        }

      

        public void StartReceive()
        {
            while (true)
            {
                var stream = _tcpClient.GetStream();
                stream.Read(_messageLenght, 0, _messageLenght.Length);

                var data = new byte[BitConverter.ToInt32(_messageLenght, 0)];
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

    

        public void StartSend()
        {
            while (true)
            {
                if (_messageQueue.Count == 0)
                    continue;

                var message = _messageQueue.Dequeue();
                var stream=_tcpClient.GetStream();

                
                var data=message.GetBytes();

                var dataLenght = BitConverter.GetBytes(data.Length);

                stream.Write(dataLenght, 0, dataLenght.Length);
                stream.Write(data, 0, data.Length);



            }

            

        }

        public void SendMessage(Message message)
        {
          

            this._messageQueue.Enqueue(message);
        }

        public Message ReceiveMessage()
        {
            throw new NotImplementedException();
        }
    }
}
