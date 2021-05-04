using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZPool.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Email { get; set; }
        public string  Introduction { get; set; }
    


        //Navigation properties
        public ICollection<Car> Cars { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
