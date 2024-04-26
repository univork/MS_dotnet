using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Product(string title, string description, decimal price, string category)
    {
        public string title = title;
        public string description = description;
        public decimal price = price;
        public string category = category;
    }
}
