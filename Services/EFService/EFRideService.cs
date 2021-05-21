using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Pages.Rides;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService.RideService
{
    public class RideService : IRideService
    {
        AppDbContext _context;
        
        public RideService(AppDbContext context)
        {
            _context = context;
        }

        public void AddRide(Ride ride)
        {
            _context.Rides.Add(ride);
            _context.SaveChanges();
        }

        public void DeleteRide(Ride ride)
        {
            _context.Rides.Remove(ride);
            _context.SaveChanges();
        }

        public void EditRide(Ride ride)
        {
            _context.Rides.Update(ride);
            _context.SaveChanges();  
        }

        public IEnumerable<Ride> GetAllRides()
        {
            return _context.Rides
                .Include(r => r.Car)
                .ThenInclude(c => c.AppUser);
        }

        public Ride GetRide(int rideId)
        {
            return _context.Rides
                .Include(r=>r.Car)
                .ThenInclude(c=>c.AppUser)
                .FirstOrDefault(r=>r.RideID==rideId);
        }

        public IEnumerable<Car> GetRegisteredCars(int userId)
        {
            var cars = _context.Cars.AsNoTracking().Where(c => c.AppUserID == userId);
            return cars;
        }

        public IEnumerable<Ride> FilterRides(RideCriteriaInputModel criteria)
        {
            var rides = _context.Rides
                .Include(r=>r.Car)
                .AsNoTracking()
                .AsEnumerable()
                .Where(ride=>CheckDeparture(ride, criteria.DepartureLocation))
                .Where(ride=>CheckDestination(ride, criteria.DestinationLocation))
                .Where(ride=>CheckStartTime(ride, criteria.StartTime))
                .OrderBy(r=>r.StartTime);
            return rides;
        }

        #region FilterHelperMethods

        private bool CheckDeparture(Ride ride, string location)
        {
            if (string.IsNullOrEmpty(location)) return true;
            else if (ride.DepartureLocation.ToLower().Contains(location.ToLower())) return true;
            else return false;
        }

        private bool CheckDestination(Ride ride, string location)
        {
            if (string.IsNullOrEmpty(location)) return true;
            else if (ride.DestinationLocation.ToLower().Contains(location.ToLower())) return true;
            else return false;
        }

        private bool CheckStartTime(Ride ride, DateTime searchTime)
        {
            bool inRange = (ride.StartTime >= searchTime.Subtract(new TimeSpan(2, 0, 0)) &&
                            ride.StartTime <= searchTime.Add(new TimeSpan(2, 0, 0)));
            return inRange ? true : false;
        }

        #endregion

        // Method for Profile page
        public IEnumerable<Ride> GetRidesByUser(AppUser user)
        {
            IEnumerable<int> lst = _context.Cars.Where(c => c.AppUserID.Equals(user.Id)).ToList().Select(c => c.CarID);
            return from r in _context.Rides where lst.Contains(r.CarID) select r;
        }

        public int SeatsLeft(int rideId)
        {
            int acceptedBookings = _context.Bookings
                .Where(b => b.RideID == rideId)
                .Count(b => b.BookingStatus == "Accepted");

            int seatsLeft = _context.Rides.Find(rideId).SeatsAvailable - acceptedBookings;

            return seatsLeft;
        }
    }
}
