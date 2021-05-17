using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;
using ZPool.Models;
using ZPool.Services.Interface;

namespace ZPool.Services.EFService
{ }
//    public class UserService : IUserService
//    {
//        //private AppDbContext DbContext;
//        //private IBookingService BookingService;
//        //private ICarService CarService;
//        //private IRideService RideService;


//        //public UserService(AppDbContext context, IBookingService bService, ICarService cService, IRideService rService)
//        //{
//        //    DbContext = context;
//        //    BookingService = bService;
//        //    CarService = cService;
//        //    RideService = rService;
//        //}

//        //public void DeleteBookingsByUser(AppUser user)
//        //{

//        //    using (Booking bookings = new Booking())
//        //    {
//        //        var x = (from y in bookings.AppUserID
//        //                 where y.AppUserID == user.Id
//        //                 select y).FirstOrDefault();
//        //        bookings.DeleteObject(x);
//        //        bookings.SaveChanges();
//        //}



//        //public void DeleteUserProfile(AppUser user)
//        //{

            

////            delete user from dbContext.





//            //            [Bookings]
//            //From[Bookings]
//            //inner join Rides on Rides.RideId = [Bookings].RideID
//            //where rides.CarID = @CarID
//            //delete from Rides where CarID = @CarID
//            //delete from[Cars] where CarID = @CarID;


//            //            service.Bookings.Remove(from booking
//            //                  in service.Bookings.
//            //                  Where(b => b.AppUserID.Equals(user.Id))
//            //                                    select booking;)
//            //            service.SaveChanges();

//        }






//        public IEnumerable<Booking> GetBookingsByUser(AppUser user)
//        {

//        }
//    }
//}
