using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;

namespace ZPool.Services.Interfaces
{
    public interface IRideService
    {
        public void AddRide(Ride ride);
        public void DeleteRide(Ride ride);
        public Ride GetRide(int id);
        public IEnumerable<Ride> GetAllRides();
        public void EditRide(Ride ride);
    }
}
