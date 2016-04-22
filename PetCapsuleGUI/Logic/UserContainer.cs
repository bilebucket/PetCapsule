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

        public User User
        {
            get { return user; }
            set {
                user = value;
                users.Add(user);         
                }
        }

        public UserContainer()
        {
        }

        public static User getUserByEmailAndUsername(string username, string email)
        {
            foreach (User u in users)
            {
                if (u.Username == username && u.Email == email)
                {
                    return u;
                }
            }
            return null;
        }

        static public void replaceUser(User oldUser, User newUser)
        {
            users.Remove(oldUser);
            users.Add(newUser);
            user = newUser;
        }

        static public List<User> Users
        {
            get {
                return users;
            }
            set {
                if (value == null)
                {
                    users = new List<User>();
                } users = value;
            }
        }

        public static void addUser(User u)
        {
            if (users == null)
            {
                users = new List<User>();
            }
            users.Add(u);
            user = u;
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

        //Päivitetään User -olion tiedot ja tallennetaan muutokset tiedostoon
        public static void replaceUserInfo()
        {
            User oldUser = UserContainer.user;

            User newUser = new User(oldUser.Username, oldUser.Password, oldUser.Email, oldUser.Firstname, oldUser.Lastname, oldUser.Address, oldUser.City);
            newUser.Cages = oldUser.Cages;

            UserContainer.replaceUser(oldUser, newUser);
            FileLoader c = new FileLoader(@"assets/users.json", UserContainer.Users);
            c.writeUserData();
        }

        public static bool usernameAvailable(string username)
        {
            foreach(User u in users)
            {
                if (u.Username == username) return false;
            }
            return true;
        }

        public static bool emailAvailable(string email)
        {   
            foreach(User u in users)
            {
                if (u.Email == email) return false;
            }
            return true;
        }
    }
}
