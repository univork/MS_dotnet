using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_03_class
{
    public class Train
    {
        private int wagon_num;
        private int people_in_wagon;
        public double ticket_price;
        public int total_tickets;

        public void setVars(int wagon_num, int people_in_wagon, double ticket_price, int total_tickets)
        {
            this.wagon_num = wagon_num;
            this.people_in_wagon = people_in_wagon;
            this.ticket_price = ticket_price;
            this.total_tickets = total_tickets;
        }

        public void getVars()
        {
            Console.WriteLine($"Wagons: {this.wagon_num}");
            Console.WriteLine($"People in wagon: {this.people_in_wagon}");
            Console.WriteLine($"Ticket Price: {this.ticket_price}");
            Console.WriteLine($"Total Tickets: {this.total_tickets}");
        }

        public void income()
        {
            Console.WriteLine(this.ticket_price * this.total_tickets);
        }
    }
}
