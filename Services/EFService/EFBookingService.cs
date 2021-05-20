using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService
{
    public class EFBookingService: IBookingService
    {
        private AppDbContext service;
        private IMessageService _messageService;

        public EFBookingService(AppDbContext context, IMessageService smsService)
        {
           service = context;
           _messageService = smsService;
        }

        public bool AlreadyBooked(int rideId, int userId)
        {
            int check = service.Bookings
                .Where(b => b.RideID == rideId)
                .Where(b=> b.BookingStatus == "Pending" || b.BookingStatus == "Accepted")
                .Count(b => b.AppUserID == userId);
            return (check > 0) ? true : false;
        }

        public void AddBooking(Booking booking)
        {
            if (!AlreadyBooked(booking.RideID, booking.AppUserID))
            {
                service.Bookings.Add(booking);
                service.SaveChanges();
                SendMessageToDriver(booking);
            }
        }

        private void SendMessageToDriver(Booking booking)
        {
            Message message = new Message();
            message.SenderId = booking.AppUserID;
            message.ReceiverId = booking.Ride.Car.AppUserID;
            message.SendingDate = DateTime.Now;
            message.MessageBody =
                $"This is an automatic notification. You have a new booking request from {booking.AppUser.UserName}. Please check your bookings.";
            _messageService.CreateMessage(message);
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
            return service.Bookings
            .Include(b => b.Ride).ThenInclude(r => r.Car).
             ThenInclude(c =>c.AppUser)
            .Include(b => b.AppUser);
        }

        public Booking GetBookingsByID(int id)
        {
             return service.Bookings.Find(id);
        }
        
        // Method for Profile page
        public IEnumerable<Booking> GetBookingsByUser(AppUser user)
        {
            return from booking
                   in service.Bookings.Include(r => r.Ride).ThenInclude(c => c.Car).
                   ThenInclude(c => c.AppUser).
                   Where(b => b.AppUserID.Equals(user.Id))
                   select booking;
        }

        public IEnumerable<Booking> GetBookingsByRideId(int rideId)
        {
            return from booking
                   in service.Bookings.
                   Where(b => b.RideID.Equals(rideId))
                   select booking;
        }

        //public IEnumerable<Booking> GetBookingsByRide(Ride ride)
        //{
        //    return from booking
        //           in service.Bookings.
        //           Where(b => b.Ride.Equals(ride))
        //           select booking;
        //}

        public void UpdateBookingStatus(int id, string newBookingStatus)
        {
           
            Booking oldBooking = service.Bookings.Find(id);
            if (oldBooking.BookingStatus == "Cancelled")
            {
                throw new ArgumentException("The status of cancelled bookings cannot be changed.");
            }
            //else if (/*newBookingStatus == "Cancelled"*//* &&*/ oldBooking.BookingStatus != "Accepted")
            //{
            //    throw new ArgumentException("Bookings not accepted cannot be cancelled.");
            //}
            else if ((newBookingStatus == "Rejected" || newBookingStatus == "Accepted" || newBookingStatus == "Cancelled" )  && oldBooking.BookingStatus != "Pending")
            {
                throw new ArgumentException("Pending bookings can only be changed to accepted, rejected or cancelled.");
            }
            else if (newBookingStatus == "Pending")
            {
                throw new ArgumentException("A booking status cannot be changed to pending.");
            }
            oldBooking.BookingStatus = newBookingStatus;
            service.SaveChanges();
        }
    }
         
    
}
