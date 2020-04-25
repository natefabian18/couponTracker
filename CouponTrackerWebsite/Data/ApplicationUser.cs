using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponTrackerWebsite.Data
{
       public class AppUser : IdentityUser
        {
        public AppUserType? ApplicationUser { get; set; }
        public enum AppUserType
            {
                Standard = 0,
                Mod = 1,
            }
        }
}
