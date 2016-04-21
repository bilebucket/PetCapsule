using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PetCapsuleGUI.Logic
{
    class FileLoader
    {
        private string filename;
        private List<User> users = new List<User>();
       

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public FileLoader(string filename)
        {
            this.filename = filename;
            Users = new List<User>();
        }

        public FileLoader(string filename, List<User> users)
        {
            this.filename = filename;
            Users = users;
            // System.Diagnostics.Debug.WriteLine(Path.GetFullPath(filename));
        }

        public void readUserData()
        {
            try
            {
                string fileContents = System.IO.File.ReadAllText(this.filename);

                try
                {
                    users = JsonConvert.DeserializeObject<List<User>>(fileContents);
                    System.Diagnostics.Debug.WriteLine("USERS: " + users);
                }
                catch (JsonReaderException e) { System.Diagnostics.Debug.WriteLine("UH OH\n" + e);  }
                catch (JsonSerializationException e) { System.Diagnostics.Debug.WriteLine("UH OH\n" + e); }


            }
            catch (FileNotFoundException e) { System.Diagnostics.Debug.WriteLine("UH OH\n" + e); }
        }

        public void writeUserData()
        {
            string output = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filename, output);
        }
    }
}
