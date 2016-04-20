using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCapsuleGUI.Logic
{
    class Pet
    {
        private string name;
        private string species;
        private string breed;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public Pet(string name, string species, string breed)
        {
            Name = name;
            Species = species;
            Breed = breed;
        }
    }
}
