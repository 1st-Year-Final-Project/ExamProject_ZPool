using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;

namespace ZPool.Services.Interface
{
   public  interface IBookingService
    {
   
        public IEnumerable<Booking> GetBookings();
        public Booking GetBookingsByID(int id);
        public void AddBooking(Booking booking);
        public void DeleteBooking(Booking booking);
        public void EditBooking(Booking booking);

        //Method need for profile page
        IEnumerable<Booking> GetBookingsByUser(int userId);


    }
}
