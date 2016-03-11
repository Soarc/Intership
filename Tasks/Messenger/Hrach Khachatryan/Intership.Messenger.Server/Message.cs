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

            var messageIdBytes = new byte[8];
            Array.Copy(bytes, 0, messageIdBytes, 0 , 8);
            _messageId = BitConverter.ToInt64(messageIdBytes, 0);

            var timeStampBytes = new byte[8];
            Array.Copy(bytes, 0, messageIdBytes, messageIdBytes.Length, 8);
            _timestamp = new DateTime (BitConverter.ToInt64(timeStampBytes, 0));

            var clientIdBytes = new byte[4];
            Array.Copy(bytes, 0, clientIdBytes, messageIdBytes.Length + timeStampBytes.Length, 4);
            _clientId = BitConverter.ToInt32(clientIdBytes, 0);

            _message = System.Text.Encoding.UTF8.GetString(bytes, messageIdBytes.Length + timeStampBytes.Length + clientIdBytes.Length, bytes.Length - 2*sizeof(long)  - sizeof(int));
            
        }

    



    }
}
