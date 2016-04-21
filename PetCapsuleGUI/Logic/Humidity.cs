using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCapsuleGUI.Logic
{
    [JsonObject(MemberSerialization.OptIn)]
    class Humidity
    {
        public string info = "";
        private float minHumidity = 50;
        private float maxHumidity = 100;
        private float humidity = 60;
        [JsonProperty]
        public float CurrentHumidity
        {
            get
            {
                return humidity;
            }
            set
            {
                if (value < minHumidity)
                {
                    info = "Set to minimum: " + minHumidity;
                    value = minHumidity;
                }
                else if (value > maxHumidity)
                {
                    info = "Set to maximum: " + maxHumidity;
                    value = maxHumidity;
                }
                else
                {
                    info = "Set to: " + humidity;
                    humidity = value;
                }
            }
        }
    }
}
