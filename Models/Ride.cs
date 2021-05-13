using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Models
{
    public class Ride
    {
        [Key]
        [Column("RideID")]
        public int RideID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public string DepartureLocation { get; set; }
        
        [Required]
        public string DestinationLocation { get; set; }

        [Required]
        [Range(typeof(int), "1", "9")]
        public int SeatsAvailable { get; set; }

        //Foreign Keys
        [ForeignKey("CarID")]
        public int CarID { get; set; } //FK


        //Navigation properties
        public Car Car { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
