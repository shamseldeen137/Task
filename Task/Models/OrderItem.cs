using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            OrderItemAddons = new HashSet<OrderItemAddon>();
        }

        public Guid Id { get; set; }
        public byte Quantity { get; set; }
        public string OrderItemStatus { get; set; }
        public Guid OrderId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public string AddetionalData { get; set; }
        public Guid? MarketItemId { get; set; }
        public int? ItemType { get; set; }
        public Guid? StoreItemId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? MedicineId { get; set; }
        public double? TotalPrice { get; set; }

        public virtual Item MarketItem { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoreItem StoreItem { get; set; }
        public virtual ICollection<OrderItemAddon> OrderItemAddons { get; set; }
    }
}
