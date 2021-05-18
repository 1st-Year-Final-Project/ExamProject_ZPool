using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class BookingsForOneRideModel : PageModel
    {

        public UserManager<AppUser> _manager;
        public IRideService _rideService;
        public IEnumerable<Ride> _myRidesList;

        public IBookingService _bookService;
        public IEnumerable<Booking> _bookingsOfOneRide;

        //public Dictionary<Ride, IEnumerable<Booking>> _rideBookingMap;

        [BindProperty] public Ride MyRide { get; set; }
        //[BindProperty] public IEnumerable<Booking> BookingsOfOneRide { get; set; }

        public BookingsForOneRideModel(UserManager<AppUser> manager, IRideService service, IBookingService bookService)
        {
            _rideService = service;
            _bookService = bookService;
            _manager = manager;
        }

        public void OnGet(int rideId)
        {
            MyRide = _rideService.GetRide(rideId);
            //BookingsOfOneRide = _bookService.GetBookingsByRideId(rideId);
        }


        public IEnumerable<Booking> GetBookingsByRideId(int rideId)
        {
            return _bookService.GetBookingsByRideId(rideId);
        }


        //public async Task OnGet()
        //{
        //    AppUser user = await _manager.GetUserAsync(User);
        //    _myRidesList = _rideService.GetRidesByUser(user);
        //    //_bookingsOfOneRide = _bookService.GetBookingsByRide(_myRidesList);
        //    this._rideBookingMap = GetAllBookingsByRides(_myRidesList);
        //}

        //private Dictionary<Ride, IEnumerable<Booking>> GetAllBookingsByRides(IEnumerable<Ride> rides)
        //{
        //    Dictionary<Ride, IEnumerable<Booking>> dictionaryOfBookingsForOneRide = new Dictionary<Ride, IEnumerable<Booking>>();
        //    foreach (Ride ride in rides)
        //    {
        //        IEnumerable<Booking> bookings = _bookService.GetBookingsByRide(ride);
        //        if (bookings != null && bookings.Count() > 0) { dictionaryOfBookingsForOneRide.Add(ride, bookings); }
        //    }

        //    return dictionaryOfBookingsForOneRide;
        //}


    }
}
