using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;

namespace ZPool.Services.Interface
{
    interface ICarService
    {
        IEnumerable<Car> GetCars();
        void AddCar(Car car);
        void DeleteCar(Car car);
    }
}
