using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Models
{
    public class Ride
    {
        public int RideID { get; set; }

        public DateTime StartTime { get; set; }
        public string DepartureLocation { get; set; }
        public string DestinationLocation { get; set; }
        public int SeatsAvailable { get; set; }

        //Foreign Keys
        public int CarID { get; set; } //FK


        //Navigation properties

        public Car Car { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
