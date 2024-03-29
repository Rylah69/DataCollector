﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace DataCollector
{
    class MeasureLengthDevice : IMeasuringDevice
    {
        private Queue<int> dataCaptured;
        private int? mostRecentMeasure;
        Device device;
        private Timer timer;



        //Add a constructor for your class which initializes your fields
        public MeasureLengthDevice()
        {
            device = new Device();
            //unitsToUse = Units.Metric;
            dataCaptured = new Queue<int>();
            mostRecentMeasure = null;

            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
        }

        private async void timer_Tick(object state)
        {
            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                mostRecentMeasure = device.GetMeasurement;
                if (dataCaptured.Count > 26)
                {
                    dataCaptured.Dequeue();
                    dataCaptured.Enqueue((int)this.mostRecentMeasure);
                }
                else
                {
                    dataCaptured.Enqueue((int)this.mostRecentMeasure);
                }
            });
        }
        //public int GetMeasurement => data;
        public string MetricValue()
        {
            int[] displayData = this.GetRawData();
            string textDisplay = "";

            for(int i = 0; i < displayData.Length; i++)
            {
                textDisplay += displayData[i].ToString() + "kph ";
            }

            return textDisplay;
        }
        public string ImperialValue()
        {
            int[] displayData = this.GetRawData();
            string textDisplay = "";
            double num1 = 0;
            for (int i = 0; i < displayData.Length; i++)
            {
                num1 = displayData[i] * .6214;      //.6214
                num1 = Math.Ceiling(num1);
                textDisplay += num1.ToString() + "mph ";
            }

            return textDisplay;
        }
        public int GetMostRecentMeasure()
        {
            return (int)this.mostRecentMeasure;
        }

        public int[] GetRawData()
        {
            Queue<int> clone = new Queue<int>(dataCaptured);
            int[] theData = new int[dataCaptured.Count];
            for(int i = 0; i < theData.Length; i++)
            {
                theData[i] = clone.Dequeue();
            }
            return theData;
        }


        /*
        decimal MetricValue();
        decimal ImperialValue();
        void StartCollecting();
        void StopCollecting();
        int[] GetRawData();
        */
    }
}
