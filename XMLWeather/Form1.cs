using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        public static List<Day> daysList = new List<Day>();

        public static string city = "Stratford,CA";

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                //create a day object
                Day today = new Day();

                //fill day object with required data
                reader.ReadToFollowing("time");
                today.date = reader.GetAttribute("day");

                reader.ReadToFollowing("temperature");
                today.tempLow = reader.GetAttribute("min");
                today.tempHigh = reader.GetAttribute("max");

                double high = Convert.ToDouble(today.tempHigh);
                double low = Convert.ToDouble(today.tempLow);
                high = Math.Round(high, 0);
                low = Math.Round(low, 0);
                today.tempHigh = Convert.ToString(high);
                today.tempLow = Convert.ToString(low);


                //if day object not null add to the days list
                daysList.Add(today);
            }
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            daysList[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            daysList[0].currentTemp = reader.GetAttribute("value");
            double current = Convert.ToDouble(daysList[0].currentTemp);
            current = Math.Round(current, 0);
            daysList[0].currentTemp = Convert.ToString(current);

            reader.ReadToFollowing("speed");
            daysList[0].windStrength = reader.GetAttribute("value");
            daysList[0].windSpeed = reader.GetAttribute("name");

            reader.ReadToFollowing("direction");
            daysList[0].windDirection = reader.GetAttribute("code");
        }


    }
}
