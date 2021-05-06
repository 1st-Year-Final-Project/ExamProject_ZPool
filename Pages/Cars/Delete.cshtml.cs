using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ZPool.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Car Car { get; set; }

        ICarService carService;
       
        public DeleteModel(ICarService service)
        {
            this.carService = service;
            Car = new Car();
        }
        public void OnGet(int id)
        {
            Car = carService.GetCar(id);
        }
        public IActionResult OnPost()
        {
            carService.DeleteCar(Car);

            return RedirectToPage("Index");
        }
    }
}
