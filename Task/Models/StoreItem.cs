using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class StoreItem
    {
        public StoreItem()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public double Price { get; set; }
        public byte Counter { get; set; }
        public double DisCount { get; set; }
        public bool? IsOffer { get; set; }
        public bool? IsAdvertisment { get; set; }
        public double? OfferPrice { get; set; }
        public double? Kcal { get; set; }
        public bool? IsDeleted { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual StoreCategory Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
