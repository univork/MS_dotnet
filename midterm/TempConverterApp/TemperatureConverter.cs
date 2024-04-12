using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverterApp
{
    public class TemperatureConverter
    {
        protected decimal CelsiusToFahrenheit(decimal temp_in_c)
        {
            return (temp_in_c * (9 / 5)) + 32;
        }

        protected decimal FahrenheitToCelsius(decimal temp_in_f)
        {
            return (temp_in_f - 32) * (9 / 5);
        }

        public decimal ConvertTemperature(Temperature temperature)
        {
            if (temperature is Fahrenheit)
                return this.FahrenheitToCelsius(temperature.GetTemperature());
            else
                return this.CelsiusToFahrenheit(temperature.GetTemperature());
        }
    }
}
