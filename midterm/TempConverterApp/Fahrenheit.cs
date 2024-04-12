using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverterApp
{
    public class Fahrenheit : Temperature
    {
        public Fahrenheit(decimal temperature) {
            this.temperature = temperature;
        }

        public override string GetUnit()
        {
            return "F";
        }
    }
}
