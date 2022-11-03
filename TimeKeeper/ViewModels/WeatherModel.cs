using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.ViewModels
{
    internal class WeatherModel
    {
        public string Icon { get; set; }
        public string CityName { get; set; }
        public float Temp { get; set; }
        public string Description { get; set; }
        public string WindDir { get; set; }
        public string TimeZone { get; set; }
    }
}
