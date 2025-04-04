using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            label3.Parent  = pictureBox;
            forecastLabel.Parent = pictureBox;
            label5.Parent = pictureBox;




            cityOutput.Text = Form1.daysList[0].location;
            minOutput.Text = Form1.daysList[0].tempLow;
            maxOutput.Text = Form1.daysList[0].tempHigh;
            currentOutput.Text = Form1.daysList[0].currentTemp;
            windOutput.Text = $"{Form1.daysList[0].windSpeed}\n {Form1.daysList[0].windStrength}m/s, {Form1.daysList[0].windDirection}";

            timeLabel.Text = $"{DateTime.Now.ToString("hh:mm")} {DateTime.Now.ToString("M")}";
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
