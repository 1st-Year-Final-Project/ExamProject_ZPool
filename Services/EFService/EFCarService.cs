using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService
{
    public class EFCarService : ICarService
    {
        AppDbContext context;
        public EFCarService(AppDbContext service)
        {
            context = service;
        }
        public void AddCar(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        public IEnumerable<Car> GetCars()
        {
            return context.Cars;
        }
    }
}
