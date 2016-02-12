using System;

namespace MessangerServer
{
    public class Message
    {
        public User Sender { get; set; }

        public string MsgText { get; set; }

        public DateTime TimeStamp { get; }

        public void Broadcast(string str)
        {
            
        }


    }
}