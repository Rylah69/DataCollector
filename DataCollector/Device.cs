using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace DataCollector
{
    public class Device
    {
        private Timer timer;
        private int data = 0;
        Random rnd = new Random();
        Queue<int> myQueue = new Queue<int>();

        public Device()
        {
            //create a timer and set the timer event to the method
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
        }
        private async void timer_Tick(object state)
        {
            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                data = rnd.Next(50, 181);
                myQueue.Enqueue(data);
            });
        }
        public int GetMeasurement => data;

        public string History => PrintValues(myQueue);

        public string PrintValues(Queue<int> myCollection)
        { //code to return history from ConcurrentQueue
            StringBuilder myString = new StringBuilder();
            foreach (var i in myCollection)
                myString.AppendLine(i.ToString());
            return myString.ToString();
        }
    }
}

