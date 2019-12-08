using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector
{
    interface IMeasuringDevice
    {
        string MetricValue();
        string ImperialValue();
        int[] GetRawData();
        int GetMostRecentMeasure();
    }
}
