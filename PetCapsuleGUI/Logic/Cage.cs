using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCapsuleGUI.Logic
{
    class Cage
    {
        private Humidity humid;
        private Temperature temp;
        private Pet pet;

        public Humidity CageHumidity
        {
            get { return humid; }
            set { humid = value; }
        }

        public Temperature CageTemperature
        {
            get { return temp; }
            set { temp = value; }
        }

        public Pet Pet
        {
            get { return pet; }
            set { pet = value; }
        }

        public Cage(Humidity h, Temperature t)
        {
            CageHumidity = h;
            CageTemperature = t;
        }
    }
}
