using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            UserCoupons = new HashSet<UserCoupon>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ValueType { get; set; }

        public virtual ICollection<UserCoupon> UserCoupons { get; set; }
    }
}
