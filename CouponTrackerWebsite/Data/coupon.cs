using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponTrackerWebsite.Data
{
    public class coupon
    {
        public string userSubmission { get; set; }
        public int ID { get; set; }
        public string title { get; set; }
        public string hyperlink { get; set; }
        public Category category { get; set; }
    }
}
