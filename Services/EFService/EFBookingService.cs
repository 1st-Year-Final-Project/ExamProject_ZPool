using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            service.SaveChanges();
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
            .Include(b => b.Ride)
            .Include(b => b.AppUser);
        }

        public Booking GetBookingsByID(int id)
        {
         return service.Bookings.Find(id);
        }

        public void UpdateBookingStatus(int id, string newBookingStatus)
        {
           
            Booking oldBooking = service.Bookings.Find(id);
            if (oldBooking.BookingStatus == "Cancelled")
            {
                throw new ArgumentException("The status of cancelled bookings cannot be changed.");
            }
            else if (newBookingStatus == "Cancelled" && oldBooking.BookingStatus != "Accepted")
            {
                throw new ArgumentException("Bookings not accepted cannot be cancelled.");
            }
            else if ((newBookingStatus == "Rejected" || newBookingStatus == "Accepted")  && oldBooking.BookingStatus != "Pending")
            {
                throw new ArgumentException("Pending bookings can only be changed to accepted or rejected.");
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
