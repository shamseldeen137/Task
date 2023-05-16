using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string Phone { get; set; }
        public string DeliveryFee { get; set; }
        public double Price { get; set; }
        public byte? Counter { get; set; }
        public bool? IsDeleted { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual MedicineCategory Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
