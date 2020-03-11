﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CouponTrackerWebsite.Data;

namespace CouponTrackerWebsite.Pages.coupon
{
    public class DeleteModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

        public DeleteModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public coupon coupon { get; set; }

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