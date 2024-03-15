using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_03_class
{
    public class Car
    {
        private string color;
        private int doors;
        public string owner;
        public string brand;

        public Car(string color, int doors, string owner, string brand)
        {
            this.color = color;
            this.doors = doors;
            this.owner = owner;
            this.brand = brand;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Color: {color}, Number of doors: {doors}.");
        }
    }
}
