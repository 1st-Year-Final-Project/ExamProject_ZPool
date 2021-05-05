using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string NumberPlate { get; set; }
        public string Color { get; set; }
        public int NumberOfSeats { get; set; }


        //Foreign Keys
        public int AppUserId { get; set; }//FK

        //Navigation Properties
        public AppUser AppUser { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
