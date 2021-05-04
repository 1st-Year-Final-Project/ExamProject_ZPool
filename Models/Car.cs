﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Colour { get; set; }
        public int NumberOfSeats { get; set; }


        //Foreign Keys
        public int UserID { get; set; }//FK

        //Navigation Properties
        public User User { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
