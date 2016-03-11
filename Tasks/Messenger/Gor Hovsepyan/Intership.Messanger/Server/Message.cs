using System;
using System.Text;

namespace MessangerServer
{
    public class Message
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

            byte[] a  = new byte[8];
            byte[] b = new byte[8];
            byte[] c = new byte[4];
            byte[] d = new byte[bytes.Length - 20];


            

            Array.Copy(bytes, 0, a, 0, 8);
            Array.Copy(bytes, 8, b, 0, 8);
            Array.Copy(bytes, 16, c, 0, 4);
            Array.Copy(bytes, 20, d, 0, bytes.Length - 20);


            var messageid = BitConverter.ToInt64(a, 0);
            var timeStamp = DateTime.FromBinary(BitConverter.ToInt64(b, 0));
           
            var clientid = BitConverter.ToInt32(c, 0);
            var message = Encoding.UTF8.GetString(d); 







        }




    }
}