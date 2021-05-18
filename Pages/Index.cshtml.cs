using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Pages.Rides;
using ZPool.Services.Interface;

namespace UserManagementTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public RideCriteriaInputModel RideCriteria { get; set; } = new RideCriteriaInputModel();

        public IndexModel(ILogger<IndexModel> logger, IRideService service)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RideCriteria.StartTime = DateTime.Now;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Rides/GetAllRides", RideCriteria);
        }
    }
}
