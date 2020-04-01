using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CouponTrackerWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class ViewModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

        public ViewModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CouponTrackerWebsite.Data.coupon coupon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            coupon = await _context.coupon.FirstOrDefaultAsync(m => m.ID == id);

            if (coupon == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}