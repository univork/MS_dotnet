using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConverterApp
{
    public interface IConvertTemperature
    {
        public decimal ConvertTemperature(Temperature temperature);
    }
}
