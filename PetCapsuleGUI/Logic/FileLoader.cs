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
        }

        public FileLoader(string filename)
        {
            this.filename = filename;
        }


        public void readUserData()
        {
            try
            {
                string fileContents = System.IO.File.ReadAllText(this.filename);

                try
                {
                    users = JsonConvert.DeserializeObject<List<User>>(fileContents);
                }
                catch (JsonReaderException e) { }
                catch (JsonSerializationException e) { }


            }
            catch (FileNotFoundException e) { }
        }

        public void writeUserData()
        {
            string output = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filename, output);
        }
    }
}
