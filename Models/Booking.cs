using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime Date { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        

        //Foreign Keys
        public int RideID { get; set; }//FK
        public int AppUserID { get; set; }//FK


        //Navigation Properties
        public AppUser AppUser { get; set; }
        public Ride Ride { get; set; }
    }
}
