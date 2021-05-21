using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class EditCarModel : PageModel
    {
        ICarService carService;

        [BindProperty]
        public Car Car { get; set; }
        public EditCarModel(ICarService service)
        {
            carService = service;
        }
        public IActionResult OnGet(int id)
        {
            Car = carService.GetCar(id);
            if (Car == null)
            {
                return null;
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            carService.UpdateCar(Car);
            return RedirectToPage("./MyCars");
        }
    }
}
