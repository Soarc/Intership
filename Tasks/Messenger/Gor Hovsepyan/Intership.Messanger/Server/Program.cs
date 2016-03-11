using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessangerServer
{
    static class Program
    {
       
        static void Main(string[] args)
        {
            var server = new Server();
            if(args!= null && args.Length >0)
            {
                server.Config.Port = Convert.ToInt32( args[0]);
            }

            if(args != null && args.Length >1)
            {
                server.Config.Maxclients = Convert.ToInt32(args[1]);
            }

            server.Start();

            Console.ReadLine();
        }
    }
}
