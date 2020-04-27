using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CouponTrackerWebsite.Data;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class SearchModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

        public SearchModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CouponTrackerWebsite.Data.coupon> coupon { get;set; }

        public async Task OnGet()
        {
            coupon = await _context.coupon.ToListAsync();
            System.Diagnostics.Debug.WriteLine("*");
            System.Diagnostics.Debug.WriteLine(SearchString);

            var testCoupons = from m in _context.coupon
                              select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                testCoupons = testCoupons.Where(s => s.Description.Contains(SearchString));
            }

            coupon = await testCoupons.ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}
