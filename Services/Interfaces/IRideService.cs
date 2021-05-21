using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Pages.Rides;

namespace ZPool.Services.Interfaces
{
    public interface IRideService
    {
        public void AddRide(Ride ride);
        public void DeleteRide(Ride ride);
        public Ride GetRide(int rideId);
        public IEnumerable<Ride> GetAllRides();
        public void EditRide(Ride ride);
        public IEnumerable<Car> GetRegisteredCars(int userId);
        IEnumerable<Ride> FilterRides(RideCriteriaInputModel criteria);

        //Method for profile page
        public IEnumerable<Ride> GetRidesByUser(AppUser user);
        int SeatsLeft(int rideId);

    }
}
