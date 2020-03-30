using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CouponTrackerWebsite.Data;
using Microsoft.AspNetCore.Identity;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class CreateModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

 
        public CreateModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CouponTrackerWebsite.Data.coupon coupon { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string user = User.Identity.Name;
            coupon.userSubmission = user;
            _context.coupon.Add(coupon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}