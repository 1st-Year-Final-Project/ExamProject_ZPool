using System;
using Microsoft.EntityFrameworkCore;
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
        public Car GetCar(int id)
        {
            var car = context.Cars.Include(c => c.AppUser).FirstOrDefault(c => c.CarID == id);
            return car;
        }

        public void UpdateCar(Car car)
        {
            
                Car OldCar = context.Cars.Find(car.CarID);
            OldCar.CarID = car.CarID;
            OldCar.Brand = car.Brand;
            OldCar.Model = car.Model;
            OldCar.NumberOfSeats = car.NumberOfSeats;
            OldCar.NumberPlate = car.NumberPlate;
            OldCar.Color = car.Color;
            context.SaveChanges();
        }
        }
}
