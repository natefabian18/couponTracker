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
    public class IndexModel : PageModel
    {
        private readonly CouponTrackerWebsite.Data.ApplicationDbContext _context;

        public IndexModel(CouponTrackerWebsite.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CouponTrackerWebsite.Data.coupon> coupon { get;set; }

        [BindProperty]
        public int CategorySearch { get; set; }

        public async Task OnGetAsync(int categorySearch)
        {
            //coupon = await _context.coupon.ToListAsync(); //previous code left here for reference
            CategorySearch = categorySearch;

            IQueryable<Data.coupon> FilteredCoupons = _context.coupon; //the default is all coupons shown

            if (categorySearch == 1) //this section is extremely rigged please no touchy
            {
                FilteredCoupons = FilteredCoupons.Where(c => c.category.Equals(Category.Goods));
            }
            if (categorySearch == 2)
            {
                FilteredCoupons = FilteredCoupons.Where(c => c.category.Equals(Category.Dining));
            }
            if (categorySearch == 3)
            {
                FilteredCoupons = FilteredCoupons.Where(c => c.category.Equals(Category.Entertainment));
            }
            if (categorySearch == 4)
            {
                FilteredCoupons = FilteredCoupons.Where(c => c.category.Equals(Category.Travel));
            }
            if (categorySearch == 5)
            {
                FilteredCoupons = FilteredCoupons.Where(c => c.category.Equals(Category.Electronics));
            }
            coupon = await FilteredCoupons.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await Task.Yield(); //Since we're not using async, I'm putting this here to remove warning

            return RedirectToPage("./Index", new {categorySearch = CategorySearch});
        }
    }
}
