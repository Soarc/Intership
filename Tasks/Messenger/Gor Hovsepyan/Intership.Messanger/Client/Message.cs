using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerClient
{
    public class Message
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
            var clientIdBytes = BitConverter.GetBytes(_messageId);
            var messageBytes = Encoding.UTF8.GetBytes(_message);

            var result = new byte[
                messageIdBytes.Length +
                timeStampBytes.Length +
                clientIdBytes.Length +
                messageBytes.Length
                ];

            Array.Copy(messageIdBytes, 0, result, 0, messageIdBytes.Length);
            Array.Copy(timeStampBytes, 0, result, messageIdBytes.Length, timeStampBytes.Length);
            Array.Copy(clientIdBytes, 0, result, messageIdBytes.Length + timeStampBytes.Length, clientIdBytes.Length);
            Array.Copy(messageBytes, 0, result, messageIdBytes.Length + timeStampBytes.Length + clientIdBytes.Length, messageBytes.Length);



            return result;



        }

        public void ReadBytes(byte[] bytes)
        {

            var messageBytes = Encoding.UTF8.GetBytes(_message);

            byte[] a = new byte[sizeof(long)];
            byte[] b = new byte[sizeof(long)];
            byte[] c = new byte[sizeof(int)];
           


            

            Array.Copy(bytes, 0, a, 0, 8);
            Array.Copy(bytes, 8, b, 0, 8);
            Array.Copy(bytes, 16, c, 0, 4);



            _messageId = BitConverter.ToInt64(a, 0);
            _timestamp = DateTime.FromBinary(BitConverter.ToInt64(b, 0));

            _clientId = BitConverter.ToInt32(c, 0);
            _message = Encoding.UTF8.GetString(bytes, a.Length + b.Length + c.Length, bytes.Length - 2 * sizeof(long) - sizeof(int));







        }




    }
}
