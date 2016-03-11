using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intership.Messenger.Server
{
    class Message
    {
        long _messageId;
        DateTime _timestamp;
        string _message;
        int _clientId;

        public long MessageId
        {
            get
            {
                return _messageId;
            }

            set
            {
                _messageId = value;
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = value;
            }
        }

        public string MessageText
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }

        public int ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                _clientId = value;
            }
        }

        public Message()
        {
            _message = string.Empty;

        }

        public byte[] GetBytes()
        {

            var messageIdBytes = BitConverter.GetBytes(_messageId);
            var timeStampBytes = BitConverter.GetBytes(_timestamp.ToBinary());
            var messageBytes = Encoding.UTF8.GetBytes(_message);
            var clientIdBytes = BitConverter.GetBytes(_clientId);

            var result = new byte[
                messageIdBytes.Length +
                timeStampBytes.Length +
                messageBytes.Length +
                clientIdBytes.Length];

            Array.Copy(messageIdBytes, 0, result, 0, messageIdBytes.Length);
            Array.Copy(timeStampBytes, 0, result, messageIdBytes.Length, timeStampBytes.Length);
            Array.Copy(clientIdBytes, 0, result, messageIdBytes.Length + timeStampBytes.Length, clientIdBytes.Length);
            Array.Copy(messageBytes, 0, result, messageIdBytes.Length + timeStampBytes.Length + clientIdBytes.Length, messageBytes.Length);



            return result;

        }

        public void ReadBytes(byte[] bytes)
        {

           // var t = sizeof(TEst);
            var messageIdBytes = new byte[sizeof(long)];
            Array.Copy(bytes, 0, messageIdBytes, 0, messageIdBytes.Length);
            _messageId = BitConverter.ToInt64(messageIdBytes, 0);

            var timeStampBytes = new byte[sizeof(long)];
            Array.Copy(bytes, messageIdBytes.Length, timeStampBytes,0, timeStampBytes.Length);
            _timestamp =  DateTime.FromBinary(BitConverter.ToInt64(timeStampBytes, 0));

            var clientIdBytes = new byte[sizeof(int)];
            Array.Copy(bytes, messageIdBytes.Length+ timeStampBytes.Length, clientIdBytes,0,clientIdBytes.Length);
            _clientId = BitConverter.ToInt32(clientIdBytes, 0);

            _message = System.Text.Encoding.UTF8.GetString(bytes, messageIdBytes.Length + timeStampBytes.Length + clientIdBytes.Length, bytes.Length - 2 * sizeof(long) - sizeof(int));

        }

      


    }
}
