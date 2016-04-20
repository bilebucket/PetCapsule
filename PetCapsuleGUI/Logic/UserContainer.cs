using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCapsuleGUI.Logic
{
    class UserContainer
    {
        private static List<User> users = new List<User>();
        public static User user;

        public UserContainer(User u)
        {
            user = u;
            users.Add(u);
        }

        public static void addUser(User u)
        {
            users.Add(u);
        }

        public static bool loginCheck(string username, string password)
        {

            foreach(User u in users)
            {
                if (u.Username == username && u.Password == password)
                {
                    user = u;
                    return true;
                }
            }

            return false;
        }
    }
}
