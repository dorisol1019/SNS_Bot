using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weathers.Models
{
    public class WeatherHacksModel
    {
        public string title { get; set; }
        public class Location {
            public string area { get; set; }
            public string prefecture { get; set; }
            public string city { get; set; }
        }
        public Location location{get;set;}

        public string publicTime{ get; set; }

        public class Forecast{
            public string date{ get; set; }
            public string dateLabel{ get; set; }
            public string telop{ get; set; }

            public class Temperature{
                public double calsius{ get; set; }
                public double fahrenheit{ get; set; }
            }
            public Temperature temperature{ get; set; }
        }

        public Forecast[] forecasts;

    }
}
