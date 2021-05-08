using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService
{
    public class EFBookingService: IBookingService
    {
        private AppDbContext service;

        public EFBookingService(AppDbContext context)
        {
           service = context;
        }

        public void AddBooking(Booking booking)
        {
            service.Bookings.Add(booking);
        }

        public void DeleteBooking(Booking booking)
        {
            service.Bookings.Remove(booking);
            service.SaveChanges();
        }

        public void EditBooking(Booking booking)
        {
            service.Bookings.Update(booking);
            service.SaveChanges();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return service.Bookings;
        }

        public Booking GetBookingsByID(int id)
        {
         return service.Bookings.Find(id);
        }

        // Method need for profile page
        public IEnumerable<Booking> GetBookingsByUser(int userId)
        {
            return service.Bookings.Where(b=>b.AppUserID == userId);
        }
    }
         
    
}
