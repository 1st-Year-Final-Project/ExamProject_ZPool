using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService.RideService
{
    public class RideService : IRideService
    {
        AppDbContext service;
        private IDateTimeComparer dateComparer;

        public RideService(AppDbContext context, IDateTimeComparer comparer)
        {
            service = context;
            dateComparer = comparer;
        }

        public void AddRide(Ride ride)
        {
            service.Rides.Add(ride);
            service.SaveChanges();
        }

        public void DeleteRide(Ride ride)
        {
            service.Rides.Remove(ride);
            service.SaveChanges();
        }

        public void EditRide(Ride ride)
        {
            service.Rides.Update(ride);
            service.SaveChanges();  
        }

        public IEnumerable<Ride> GetAllRides()
        {
            return service.Rides; 
        }

        public Ride GetRide(int id)
        {
            return service.Rides
                .Include(r=>r.Car)
                .ThenInclude(c=>c.AppUser)
                .FirstOrDefault(r=>r.RideID==id);
        }


        public IEnumerable<Car> GetRegisteredCars(int id)
        {
            var cars = service.Cars.AsNoTracking().Where(c => c.AppUserID == id);
            return cars;
        }

        public IEnumerable<Ride> FilterRides(Ride ride)
        {
            var rides = service.Rides
                .AsNoTracking()
                .AsEnumerable()
                .Where(r=>CheckDeparture(r, ride.DepartureLocation))
                .Where(r=>CheckDestination(r, ride.DestinationLocation))
                .Where(r=>CompareDateTimes(r, ride.StartTime))
                .OrderBy(r=>r.StartTime);
            return rides;
        }

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

        private bool CompareDateTimes(Ride ride, DateTime dateCriteria)
        {
            bool suitable = dateComparer.CompareDateTime(ride.StartTime, dateCriteria);
            if (suitable) return true;
            return false;
        }
    }
}
