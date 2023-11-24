using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplesProperties
{
    class MyClass2
    {
        private int seconds;

        public int Seconds {
            get => seconds;
            set => seconds = value;
        }

        public double Minutes
        {
            get => seconds / 60.0;   // le .0 pour garantir la division comme double
            set => seconds = (int) Math.Round(value * 60);
        }

        public double Hours
        {
            get => seconds / 3600.0;  // le .0 pour garantir la division comme double 
            set => seconds = (int) Math.Round(value * 3600);
        }
    }
}
