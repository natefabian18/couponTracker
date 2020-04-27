using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CouponTrackerWebsite.Data;
using Microsoft.AspNetCore.Identity;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class EditModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EditModel(CouponTrackerWebsite.Data.ApplicationDbContext context, UserManager<AppUser> userManager)
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
            if ((User.Identity.Name != null) && (User.Identity.Name != coupon.userSubmission) && (currentUser.ApplicationUser == AppUser.AppUserType.Standard))
            {
                return RedirectToPage("/UserError");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string user = User.Identity.Name;
            coupon.userSubmission = user;
            _context.Attach(coupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!couponExists(coupon.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool couponExists(int id)
        {
            return _context.coupon.Any(e => e.ID == id);
        }
    }
}
