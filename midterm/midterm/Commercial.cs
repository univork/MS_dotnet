using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class Commercial : Software
    {
        private string name;
        private string owner;
        private DateTime launch_date;
        private decimal price;
        private DateTime instalation_date;
        private int valid_for;

        public Commercial(string name, string owner, DateTime launch_date, decimal price, DateTime instalation_date, int valid_for)
        {
            this.name = name;
            this.owner = owner;
            this.launch_date = launch_date;
            this.price = price;
            this.instalation_date = instalation_date;
            this.valid_for = valid_for;
        }

        public override string Info()
        {
            string info = $"Name: {this.name}; Owner: {this.owner}; Launch Date: {this.launch_date}; Price: {this.price}; Instalation date: {this.instalation_date}; Valid For: {this.valid_for} months;";
            return info;
        }

        public override bool IsValid()
        {
            return this.instalation_date.Month + this.valid_for > DateTime.Today.Month;
        }
    }
}
