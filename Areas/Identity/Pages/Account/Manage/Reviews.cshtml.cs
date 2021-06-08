using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Pages.Reviews
{
    [Authorize]
    public class ReviewsModel : PageModel
    {
        private IRideService _rideService;
        private IReviewService _reviewService;
        private UserManager<AppUser> _userManager;

        public ReviewsModel(IReviewService reviewService, IRideService rideService, UserManager<AppUser> userManager)
        {
            _reviewService = reviewService;
            _userManager = userManager;
            _rideService = rideService;
        }

        [BindProperty]
        public Review NewReview { get; set; }
        [ValidateNever]
        public AppUser Reviewer { get; set; }
        [ValidateNever]
        public AppUser Reviewee { get; set; }
        [BindProperty]
        public int ListLength { get; set; }
        public SelectList providedRides { get; set; }
        [BindProperty]
        public int RideId { get; set; }

        public List<Review> Reviews { get; set; }
        //public IEnumerable<Ride> Rides { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reviewer = await _userManager.GetUserAsync(User);
            Reviewee = await _userManager.FindByIdAsync(id.ToString());
            if (Reviewer == null)
            {
                return RedirectToPage("/Account/Login",
                    new { area = "Identity", returnUrl = "/Account/Manage/Reviews" });
            }

            providedRides = new SelectList(_rideService.GetRidesByUser(Reviewee), "RideID", "StartTime");

            Reviews = _reviewService.GetReviewsByUserId(Reviewee.Id);
            //Rides = _rideService.GetRidesByUser(Reviewee);
            ListLength = 15;
            return Page();
        }
        public IActionResult OnPostReview()
        {
            NewReview.ReviewDate = DateTime.Now;
            NewReview.RideId = RideId;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Reviews");
            }
            _reviewService.CreateReview(NewReview);
            return RedirectToPage("Reviews");
        }
        public async Task<IActionResult> OnPostLoadAsync()
        {
            Reviewer = await _userManager.GetUserAsync(User);
            Reviews = _reviewService.GetReviewsByUserId(Reviewer.Id);
            ListLength += 5;
            return Page();
        }
    }
}
