using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    public static class ConnectedUsers
    {
        static List<User> _users = new List<User>();

        public static void AddUser(User user)
        {
            _users.Add(user);
        }

        public static List<User> GetAllConnectedUsers()
        {
            return _users;
        }
    }
}
