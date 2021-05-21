using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Cars
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public Car Car { get; set; }

        private ICarService context;
        public IndexModel(ICarService service)
        {
            context = service;
        }
        public void OnGet()
        {
            Cars = context.GetCars();
        }
    }
}
