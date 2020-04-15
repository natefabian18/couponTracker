using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CouponTrackerWebsite.Data;

namespace CouponTrackerWebsite.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            System.Diagnostics.Debug.WriteLine("My debug string here");
        }
    }
}
