using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace midterm
{
    public class Free : Software
    {
        private string name;
        private string owner;
        private DateTime launch_date;

        public Free(string name, string owner, DateTime launch_date)
        {
            this.name = name;
            this.owner = owner;
            this.launch_date = launch_date;
        }

        public override string Info()
        {
            string info = $"Name: {this.name}; Owner: {this.owner}; Launch Date: {this.launch_date};";
            return info;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
