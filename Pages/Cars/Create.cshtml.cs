using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Pages.Cars
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public Car Car { get; set; }
        ICarService carService;
        //public CreateModel(ICarService service)
        //{
        //    this.carService = service;
        //}
        public IActionResult OnPostAsync(Car car)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            carService.AddCar(car);
            return RedirectToPage("");
        }
    }
}
