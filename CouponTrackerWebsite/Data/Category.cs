using System;
using System.ComponentModel;

namespace CouponTrackerWebsite.Data
{
    public enum Category
    {
        [Description("Goods")]
        Goods = 1,
        [Description("Dining")]
        Dining = 2,
        [Description("Entertainment")]
        Entertainment = 3,
        [Description("Travel")]
        Travel = 4,
        [Description("Electronics")]
        Electronics = 5
    }
}
