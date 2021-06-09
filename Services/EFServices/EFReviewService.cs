using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPool.Models;
using ZPool.Services.Interfaces;

namespace ZPool.Services.EFServices
{
    public class EFReviewService : IReviewService
    {

        private AppDbContext _context;

        public EFReviewService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateReview(Review Review)
        {
            _context.Reviews.Add(Review);
            _context.SaveChanges();
        }

        public List<Review> GetReviewsByUserId(int userId)
        {
            return _context.Reviews.Include(r => r.Reviewer).Include(r => r.Reviewee).Include(r=>r.Ride)
                .Where(r => r.RevieweeId == userId)
                .OrderByDescending(r => r.ReviewDate)
                .ToList();

        }
    }
}
