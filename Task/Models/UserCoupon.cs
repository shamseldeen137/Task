using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class UserCoupon
    {
        public Guid UseId { get; set; }
        public Guid VoucherId { get; set; }
        public bool? IsUsed { get; set; }

        public virtual User Use { get; set; }
        public virtual Coupon Voucher { get; set; }
    }
}
