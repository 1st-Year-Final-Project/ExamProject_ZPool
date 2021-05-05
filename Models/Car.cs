using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Colour { get; set; }
        public int NumberOfSeats { get; set; }


        //Foreign Keys
        public int AppUserId { get; set; }//FK

        //Navigation Properties
        public AppUser AppUser { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
