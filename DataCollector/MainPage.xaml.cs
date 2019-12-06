using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DataCollector
{

    public sealed partial class MainPage : Page
    {
        MeasureLengthDevice myMLD = new MeasureLengthDevice();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            int[] displayData = myMLD.GetRawData();
            string textDisplay = "";

            for (int i = 0; i < displayData.Length; i++)
            {
                textDisplay += displayData[i].ToString() + " ";
            }
            TextBlock1.Text = textDisplay;

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int x = myMLD.MetricValue();
            TextBlock2.Text = x.ToString();

        }
    }
}
