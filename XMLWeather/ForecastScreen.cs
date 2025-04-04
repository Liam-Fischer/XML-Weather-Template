using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            forecastLabel.Parent = backgroundBox;
            label3.Parent = backgroundBox;
            label5.Parent = backgroundBox;

            date1.Text = DateTime.Now.ToString("M");
            min1.Text = Form1.daysList[0].tempLow;
            max1.Text = Form1.daysList[0].tempHigh;

            date2.Text = DateTime.Now.AddDays(1).ToString("M");
            min2.Text = Form1.daysList[1].tempLow;
            max2.Text = Form1.daysList[1].tempHigh;

            date3.Text = DateTime.Now.AddDays(2).ToString("M");
            min3.Text = Form1.daysList[2].tempLow;
            max3.Text = Form1.daysList[2].tempHigh;

            date4.Text = DateTime.Now.AddDays(3).ToString("M");
            min4.Text = Form1.daysList[3].tempLow;
            max4.Text = Form1.daysList[3].tempHigh;

            date5.Text = DateTime.Now.AddDays(4).ToString("M");
            min5.Text = Form1.daysList[4].tempLow;
            max5.Text = Form1.daysList[4].tempHigh;

            date6.Text = DateTime.Now.AddDays(5).ToString("M");
            min6.Text = Form1.daysList[5].tempLow;
            max6.Text = Form1.daysList[5].tempHigh;

            date7.Text = DateTime.Now.AddDays(6).ToString("M");
            min7.Text = Form1.daysList[6].tempLow;
            max7.Text = Form1.daysList[6].tempHigh;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
