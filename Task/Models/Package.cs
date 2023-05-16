using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Package
    {
        public Package()
        {
            DriverOrderChecks = new HashSet<DriverOrderCheck>();
            OrderImages = new HashSet<OrderImage>();
            PackageProducts = new HashSet<PackageProduct>();
        }

        public Guid Id { get; set; }
        public string AddressFrom { get; set; }
        public string FromLongitude { get; set; }
        public string FromLatitude { get; set; }
        public string AddressTo { get; set; }
        public string ToLongitude { get; set; }
        public string ToLatitude { get; set; }
        public string RecipientPhone { get; set; }
        public string PackageDescription { get; set; }
        public string Address { get; set; }
        public string EstimatedDeleveryTime { get; set; }
        public double? DeliveryFee { get; set; }
        public int Status { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public string StoreName { get; set; }
        public string Notes { get; set; }
        public string EstimatedCost { get; set; }
        public int? Type { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public string OrderNumber { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DriverOrderCheck> DriverOrderChecks { get; set; }
        public virtual ICollection<OrderImage> OrderImages { get; set; }
        public virtual ICollection<PackageProduct> PackageProducts { get; set; }
    }
}
