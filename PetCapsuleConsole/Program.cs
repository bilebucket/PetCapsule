using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PetCapsuleConsole
{

    class User
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public User(string name, string pass)
        {
            this.Username = name;
            this.Password = pass;
        }
    }

    class TUI
    {
        private const string FILENAME = "users.json";

        private bool running = true;
        private List<User> users = new List<User>();
        
        // =====Pari utility metodia=====
        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nINFO: " + msg);
            Console.ResetColor();
        }

        public static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSUCCESS: " + msg);
            Console.ResetColor();
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nERROR: " + msg);
            Console.ResetColor();
        }
        //==========

        //=====Tiedoston käsittely=====
        private void readUserData()
        {
            try
            {
                string text = System.IO.File.ReadAllText(FILENAME);

                Info("Read data from " + FILENAME + ":\n" + text);
                
                    try
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(text);
                    }
                    catch (JsonReaderException e)
                    {
                        Error("JsonReaderException:\n" + e);
                    }
                    catch (JsonSerializationException e)
                    {
                        Error("JsonSerializationException:\n" + e);
                    }
                
            }
            catch (FileNotFoundException)
            {
                Error("File not found (FileNotFoundException)");
            }
        }

        private void saveUserData(List<User> users)
        {
            string output = JsonConvert.SerializeObject(users, Formatting.Indented);
            Info("Writing info: " + output);

            System.IO.StreamWriter outputFile = new System.IO.StreamWriter(FILENAME);
            outputFile.WriteLine(output);
            outputFile.Close();
        }
        //==========

        //=====Käyttäjän hallintaa=====
        private bool checkPassword(User u)
        {
            Console.Write("\nEnter password for " + u.Username + ": ");
            string password = Console.ReadLine();
            if (u.Password == password)
            {
                return true;
            }
            Error("Wrong password!");
            return false;
        }

        private bool login()
        {
            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();
            foreach(User u in users)
            {
                if (u.Username == username){
                    return checkPassword(u);
                }
            }
            Error("Wrong username!");
            return false;
        }

        private bool addUser()
        {
            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();
            foreach (User u in users)
            {
                if (u.Username == username)
                {
                    Error("Username '" + username + "' is already taken!");
                    return false;
                }
            }
            Console.Write("\nEnter a new password: ");
            string password = Console.ReadLine();
            users.Add(new User(username, password));
            return true;
        }
        //==========

        //=====Ohjelman pää-looppi=====
        public void Run()
        {
            //users.Add(new User("Sepi", "pass"));
            //users.Add(new User("Tepi", "pass2"));
            readUserData();

            while (running)
            {
                // read-eval-print loop
                Console.Write("\nPetCapsule> ");
                string input = Console.ReadLine();
                //käyttäjän syötteen käsittely
                switch (input)
                {
                    
                    case "quit":
                        running = false;
                        break;

                    case "adduser":
                        if (addUser())
                        {
                            Success("Account creation successful!");
                        }
                        else
                        {
                            Error("Failed to create account!");
                        }
                        break;

                    case "saveall":
                        saveUserData(users);
                        break;

                    case "login":
                        if (login())
                        {
                            Success("Login successful!");
                        }
                        else
                        {
                            Error("Login failed!");
                        }
                        break;

                    default:
                        Error("Unknown command:\n" + input);
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TUI tui = new TUI();
            tui.Run();
        }
    }
}
