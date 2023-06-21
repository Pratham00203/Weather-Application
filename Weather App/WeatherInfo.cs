using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    class WeatherInfo
    {
        public class location
        { 
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public int localtime_epoch { get; set; }
        }

        public class condition
        {
            public string text { get; set; }
            public string icon { get; set; }
        }

        public class current
        {
            public decimal temp_c { get ; set; }
            public  decimal wind_kph { get; set; }
            public int humidity { get; set; }
            public decimal feelslike_c { get; set; }

            public condition condition { get; set; }
        }

        public class day
        {
            public decimal maxtemp_c { get; set; }
            public decimal mintemp_c { get; set; }

            public condition condition { get; set; }   
        }

        public class forecastday
        {
            public int date_epoch { get; set; }
            public day day { get; set;}

        }

        public class forecast
        {
           public List<forecastday> forecastday { get;set; }
        }
        
        public class root
        {
            public location location { get; set; }
            public current current { get; set; }

            public forecast forecast { get; set; }  

        }
    }
}
