using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector
{
    class MainDisplayData
    {
        private int kph;
        public int Kph
        {
            get { return this.kph; }
            set { this.kph = value; }
        }

        private string displayArray;
        public string DisplayArray
        {
            get { return this.displayArray; }
            set { this.displayArray = value; }
        }

        private string displayArrayImperial;
        public string DisplayArrayImperial
        {
            get { return this.displayArrayImperial; }
            set { this.displayArrayImperial = value; }
        }
    }
}
