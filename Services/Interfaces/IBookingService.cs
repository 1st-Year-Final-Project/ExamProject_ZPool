using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;

namespace ZPool.Services.Interfaces
{
   public  interface IBookingService
    {
        public IEnumerable<Booking> GetBookings();
        public Booking GetBookingsByID(int bookingId);
        bool AlreadyBooked(int rideId, int userId);
        public void AddBooking(Booking booking);
        public void DeleteBooking(Booking booking);
        public void EditBooking(Booking booking);

        //Method to filter booking by logged in users in Bookings page
        public IEnumerable<Booking> GetBookingsByDriversID(AppUser user);

        // Method for Profile Page
        public IEnumerable<Booking> GetBookingsByUser(AppUser user);
        //public IEnumerable<Booking> GetBookingsByRide(Ride ride);
        public IEnumerable<Booking> GetBookingsByRideId(int rideId);
        public void UpdateBookingStatus(int bookingId, string newBookingStatus);
        public IEnumerable<Booking> GetBookingsByStatus(string status, AppUser user);
        public IEnumerable<Booking> GetBookingsByStatusForDrivers(string status, AppUser user);
        //public IEnumerable<Booking> GetBookingsByDateTime(DateTime DateTime1, DateTime DateTime2, AppUser user); 
    }
}
