using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class CartItem
    {
        public CartItem()
        {
            CartItemAddons = new HashSet<CartItemAddon>();
        }

        public Guid Id { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public string AddetionalData { get; set; }
        public Guid? MarketItemId { get; set; }
        public Guid? CartId { get; set; }
        public int? ItemType { get; set; }
        public Guid? StoreItemId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? MedicineId { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Item MarketItem { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoreItem StoreItem { get; set; }
        public virtual ICollection<CartItemAddon> CartItemAddons { get; set; }
    }
}
