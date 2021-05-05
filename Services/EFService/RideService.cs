﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Services.EFService.RideService
{
    public class RideService : IRideService
    {
        AppDbContext service;

        public RideService(AppDbContext context)
        {
            service = context;
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
            return service.Rides.Find(id);
        }
    }
}