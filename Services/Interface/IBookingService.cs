﻿using System;
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
        bool AlreadyBooked(int rideId, int userId);
        public void AddBooking(Booking booking);
        public void DeleteBooking(Booking booking);
        public void EditBooking(Booking booking);

        //Method to filter booking by logged in users in Bookings page
        public IEnumerable<Booking> GetBookingsByDriversID(AppUser user);

        // Method for Profile Page
        public IEnumerable<Booking> GetBookingsByUser(AppUser user);
        public IEnumerable<Booking> GetBookingsByRideId(int rideId);
        public void UpdateBookingStatus(int id, string bookingStatus);
        public IEnumerable<Booking> GetBookingsByStatus(string StatusFilter, AppUser user);
        public IEnumerable<Booking> GetBookingsByStatusForDrivers(string StatusFilter, AppUser user);
    }
}
