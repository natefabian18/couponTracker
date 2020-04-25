using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CouponTrackerWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponTrackerWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

        public IndexModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CouponTrackerWebsite.Data.coupon> coupon { get; set; }

        public async Task OnGet()
        {
            var testCoupons = from m in _context.coupon
                              select m;
            coupon = await testCoupons.ToListAsync();
        }
    }
}
