﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Services.EFServices
{
    public class EFBookingService: IBookingService
    {
        private AppDbContext _context;
        private IMessageService _messageService;

        public EFBookingService(AppDbContext context, IMessageService smsService)
        {
           _context = context;
           _messageService = smsService;
        }
        
        public void AddBooking(Booking booking)
        {
            if (!AlreadyBooked(booking.RideID, booking.AppUserID))
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                SendMessageToDriver(booking);
            }
        }

        public bool AlreadyBooked(int rideId, int userId)
        {
            int check = _context.Bookings
                .Where(b => b.RideID == rideId)
                .Where(b => b.BookingStatus == "Pending" || b.BookingStatus == "Accepted")
                .Count(b => b.AppUserID == userId);
            return (check > 0) ? true : false;
        }

        private void SendMessageToDriver(Booking booking)
        {
            Message message = new Message
            {
                SenderId = booking.AppUserID,
                ReceiverId = booking.Ride.Car.AppUserID,
                SendingDate = DateTime.Now,
                MessageBody =
                $"You have a new booking request from {booking.AppUser.UserName}. You can contact the passenger by using the Reply function."
            };
            _messageService.CreateMessage(message);
        }

        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

        public void EditBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings
            .Include(b => b.Ride).ThenInclude(r => r.Car).
             ThenInclude(c => c.AppUser)
            .Include(b => b.AppUser);
        }

        public Booking GetBookingsByID(int bookingId) 
        {
             return _context.Bookings.Find(bookingId);
        }

        //Method for filtering bookings for users in Bookings page
        public IEnumerable<Booking> GetBookingsByDriversID(AppUser user)
        {
            return _context.Bookings
            .Include(b => b.Ride).ThenInclude(r => r.Car).
             ThenInclude(c => c.AppUser)
            .Include(b => b.AppUser).Where(b => b.Ride.Car.AppUserID.Equals(user.Id));
        }


        // Method for Profile page
        public IEnumerable<Booking> GetBookingsByUser(AppUser user)
        {
            return from booking
                   in _context.Bookings.Include(r => r.Ride).ThenInclude(c => c.Car).
                   ThenInclude(c => c.AppUser).
                   Where(b => b.AppUserID.Equals(user.Id))
                   select booking;
        }

        public IEnumerable<Booking> GetBookingsByRideId(int rideId)
        {
            return from booking
                   in _context.Bookings.
                   Where(b => b.RideID.Equals(rideId))
                   select booking;
        }

        public void UpdateBookingStatus(int bookingId, string newBookingStatus)
        {           
            Booking oldBooking = _context.Bookings.Find(bookingId);
            if (oldBooking.BookingStatus == "Cancelled" || oldBooking.BookingStatus == "Rejected")
            {
                throw new ArgumentException("The status of cancelled or rejected bookings cannot be changed.");
            }
           
            else if ((newBookingStatus == "Rejected" || newBookingStatus == "Accepted")  && oldBooking.BookingStatus != "Pending")
            {
                throw new ArgumentException("Only pending bookings can be changed to accepted, rejected or cancelled.");
            }
            else if (newBookingStatus == "Pending")
            {
                throw new ArgumentException("A booking status cannot be changed to pending.");
            }
            oldBooking.BookingStatus = newBookingStatus;
            _context.SaveChanges();
        }

        // For the profile function My Bookings
        public IEnumerable<Booking> GetBookingsByStatus(string status, AppUser user)
        {
            return _context.Bookings
            .Include(b => b.Ride).ThenInclude(r => r.Car)
            .ThenInclude(c => c.AppUser)
            .Include(b => b.AppUser)
            .Where(b=>b.BookingStatus.Equals(status))
            .Where(b=>b.AppUser.Equals(user));
        }

        // For the top bar function Bookings
        public IEnumerable<Booking> GetBookingsByStatusForDrivers(string status, AppUser user)
        {
            return _context.Bookings
            .Include(b => b.Ride).ThenInclude(r => r.Car)
            .ThenInclude(c => c.AppUser)
            .Include(b => b.AppUser)
            .Where(b => b.BookingStatus.Equals(status))
            .Where(b => b.Ride.Car.AppUser.Equals(user));
        }
    }
}