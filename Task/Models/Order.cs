using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Order
    {
        public Order()
        {
            DriverOrderChecks = new HashSet<DriverOrderCheck>();
            OrderImages = new HashSet<OrderImage>();
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int? StoreType { get; set; }
        public int? OrderStatus { get; set; }
        public Guid ChargeAddressId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public string DeliveredTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public double? DeliveryTimeTo { get; set; }
        public double? DeliveryTimeFrom { get; set; }
        public double? TotalPriceAfterVoucher { get; set; }
        public string Number { get; set; }

        public virtual ChargeAddress ChargeAddress { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DriverOrderCheck> DriverOrderChecks { get; set; }
        public virtual ICollection<OrderImage> OrderImages { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
