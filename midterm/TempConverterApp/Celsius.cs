using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverterApp
{
    public class Celsius: Temperature
    {
        public Celsius(decimal temperature) {
            this.temperature = temperature;
        }

        public override string GetUnit()
        {
            return "C";
        }
    }
}
