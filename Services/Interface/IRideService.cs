using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Pages.Rides;

namespace ZPool.Services.Interface
{
    public interface IRideService
    {
        public void AddRide(Ride ride);
        public void DeleteRide(Ride ride);
        public Ride GetRide(int id);
        public IEnumerable<Ride> GetAllRides();
        public void EditRide(Ride ride);
        public IEnumerable<Car> GetRegisteredCars(int id);
        IEnumerable<Ride> FilterRides(RideCriteriaInputModel ride);

        //Method for profile page
        public IEnumerable<Ride> GetRidesByUser(AppUser user);

    }
}
