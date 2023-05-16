using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            ChargeAddresses = new HashSet<ChargeAddress>();
            DeliveryMen = new HashSet<DeliveryMan>();
            GeneralCarts = new HashSet<GeneralCart>();
            Orders = new HashSet<Order>();
            Packages = new HashSet<Package>();
            Products = new HashSet<Product>();
            UserCoupons = new HashSet<UserCoupon>();
            UserNotifications = new HashSet<UserNotification>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string DeviceToken { get; set; }
        public int Type { get; set; }
        public string Password { get; set; }
        public bool IsHasTempPassword { get; set; }
        public string TempPassword { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsBlocked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Gender { get; set; }
        public double Coins { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ChargeAddress> ChargeAddresses { get; set; }
        public virtual ICollection<DeliveryMan> DeliveryMen { get; set; }
        public virtual ICollection<GeneralCart> GeneralCarts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<UserCoupon> UserCoupons { get; set; }
        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
