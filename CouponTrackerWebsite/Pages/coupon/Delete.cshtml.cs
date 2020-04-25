using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CouponTrackerWebsite.Data;
using Microsoft.AspNetCore.Identity;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class DeleteModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public DeleteModel(CouponTrackerWebsite.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
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

            AppUser currentUser = _context.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(HttpContext.User));
            if ((User.Identity.Name != coupon.userSubmission) && (currentUser.ApplicationUser == AppUser.AppUserType.Standard))
            {
                return RedirectToPage("/UserError");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            coupon = await _context.coupon.FindAsync(id);

            if (coupon != null)
            {
                _context.coupon.Remove(coupon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
