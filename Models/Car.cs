using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Models
{
    public class Car
    {
        public int CarID { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string NumberPlate { get; set; }
        public string Color { get; set; }
        [Range(typeof(int), "1", "9")]
        public int NumberOfSeats { get; set; }


        //Foreign Keys
        public int AppUserID { get; set; }//FK

        //Navigation Properties
        public AppUser AppUser { get; set; }
        public ICollection<Ride> Rides { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model}, {Color}";
        }
    }
}
