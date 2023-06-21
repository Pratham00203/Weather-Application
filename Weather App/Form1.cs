using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace Weather_App
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
        }

        string APIKey = "968da8a9ed7a4064aa741809230904";

        void getWeather()
        {
            try
            {
                if(textSearch.Text.Trim() != "")
                {
                    using (WebClient web = new WebClient())
                    {
                        string url = $"https://api.weatherapi.com/v1/forecast.json?q={textSearch.Text}&days=4&key={APIKey}";
                        var json = web.DownloadString(url);
                        WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                        labLocation.Text = $"{Info.location.name}, {Info.location.region}, {Info.location.country}";
                        labLocalTime.Text = convertTime(Info.location.localtime_epoch).ToShortTimeString().ToString();
                        labTemp.Text = Info.current.temp_c.ToString() + " \u2103";
                        labFeelsLike.Text = Info.current.feelslike_c.ToString() + " \u2103";
                        labWind.Text = Info.current.wind_kph.ToString() + " kph";
                        labHumidity.Text = Info.current.humidity.ToString();
                        ConditionIcon.ImageLocation = $"https:{Info.current.condition.icon}";
                        labConditionText.Text = Info.current.condition.text;

                        labDay1Date.Text = convertTime(Info.forecast.forecastday[1].date_epoch).ToShortDateString().ToString();
                        labDay1MaxTemp.Text = Info.forecast.forecastday[1].day.maxtemp_c.ToString();
                        labDay1MinTemp.Text = Info.forecast.forecastday[1].day.mintemp_c.ToString();
                        labDay1Condition.Text = Info.forecast.forecastday[1].day.condition.text;
                        day1ConditionIcon.ImageLocation = $"https:{Info.forecast.forecastday[1].day.condition.icon}";

                        labDay2Date.Text = convertTime(Info.forecast.forecastday[2].date_epoch).ToShortDateString().ToString();
                        labDay2MaxTemp.Text = Info.forecast.forecastday[2].day.maxtemp_c.ToString();
                        labDay2MinTemp.Text = Info.forecast.forecastday[2].day.mintemp_c.ToString();
                        labDay2Condition.Text = Info.forecast.forecastday[2].day.condition.text;
                        day2ConditionIcon.ImageLocation = $"https:{Info.forecast.forecastday[2].day.condition.icon}";

                        labDay3Date.Text = convertTime(Info.forecast.forecastday[3].date_epoch).ToShortDateString().ToString();
                        labDay3MaxTemp.Text = Info.forecast.forecastday[3].day.maxtemp_c.ToString();
                        labDay3MinTemp.Text = Info.forecast.forecastday[3].day.mintemp_c.ToString();
                        labDay3Condition.Text = Info.forecast.forecastday[3].day.condition.text;
                        day3ConditionIcon.ImageLocation = $"https:{Info.forecast.forecastday[3].day.condition.icon}";

                        textSearch.Clear();

                    }
                }
                else
                {
                    MessageBox.Show("Enter a valid city, region or country name!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("There was a problem finding weather details! Please try again");
            }

           
        }

        DateTime convertTime(long seconds)
        {

            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();

            return day;
        }
    }
}
