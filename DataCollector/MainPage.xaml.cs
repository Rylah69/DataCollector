using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
        MainDisplayData displayData = null;
        private Timer timer;
        public MainPage()
        {
            this.InitializeComponent();
            displayData = new MainDisplayData();

            timer = new Timer(timer_Tick, null, 
                (int)TimeSpan.FromSeconds(1).TotalMilliseconds, 
                (int)TimeSpan.FromSeconds(3).TotalMilliseconds);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock1.Text = "";
            TextBlock1.Text = myMLD.ImperialValue();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            TextBlock2.Text = "";
            TextBlock2.Text = myMLD.MetricValue();
        }

        private void GetSingleMeasurement_Click(object sender, RoutedEventArgs e)
        {
            singleMeasuretextBlock.Text = "";

            singleMeasuretextBlock.Text = myMLD.GetMostRecentMeasure().ToString();

        }

        private async void timer_Tick(object state)
        {
            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                displayData.Kph = myMLD.GetMostRecentMeasure();
                displayData.DisplayArray = myMLD.MetricValue();
                displayData.DisplayArrayImperial = myMLD.ImperialValue();
                this.DataContext = null;
                this.DataContext = displayData;
            });
        }

    }
}
