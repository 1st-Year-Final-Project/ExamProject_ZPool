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
        AppDbContext _context;
        public EFCarService(AppDbContext service)
        {
            _context = service;
        }
        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.FromSqlRaw("spDeleteCarByID {0}", car.CarID)
                .ToList()
                .FirstOrDefault();
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }
        public Car GetCar(int carId)
        {
            var car = _context.Cars.Include(c => c.AppUser).FirstOrDefault(c => c.CarID == carId);
            return car;
        }

        public void UpdateCar(Car car)
        {
            Car oldCar = _context.Cars.Find(car.CarID);
            oldCar.CarID = car.CarID;
            oldCar.Brand = car.Brand;
            oldCar.Model = car.Model;
            oldCar.NumberOfSeats = car.NumberOfSeats;
            oldCar.NumberPlate = car.NumberPlate;
            oldCar.Color = car.Color;
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetCarsByUser(int userId)
        {
            var cars = _context.Cars.AsNoTracking().Where(c => c.AppUserID == userId);
            return cars;
        }
    }
}
