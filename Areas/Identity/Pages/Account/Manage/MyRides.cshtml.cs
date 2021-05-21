using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Areas.Identity.Pages.Account.Manage
{
    public class MyRidesModel : PageModel
    {

        public UserManager<AppUser> _manager;
        public IRideService _rideService;
        public IEnumerable<Ride> _myRidesList;

        public IBookingService _bookService;
        public IEnumerable<Booking> _bookingsOfOneRide;

        public Dictionary<Ride, IEnumerable<Booking>> _rideBookingMap;

        public MyRidesModel(UserManager<AppUser> manager, IRideService service, IBookingService bookService)
        {
            _rideService = service;
            _bookService = bookService;
            _manager = manager;
        }

        public async Task OnGet()
        {
            AppUser user = await _manager.GetUserAsync(User);
            _myRidesList = _rideService.GetRidesByUser(user);
            //_bookingsOfOneRide = _bookService.GetBookingsByRide(_myRidesList);
            //this._rideBookingMap = GetAllBookingsByRides(_myRidesList);
        }

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
