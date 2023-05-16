using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralCartItem
    {
        public GeneralCartItem()
        {
            GeneralCartItemAddons = new HashSet<GeneralCartItemAddon>();
        }

        public Guid Id { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public string AddetionalData { get; set; }
        public Guid? GeneralCartId { get; set; }
        public int? ItemType { get; set; }
        public Guid? GeneralItemId { get; set; }
        public double? TotalPrice { get; set; }

        public virtual GeneralCart GeneralCart { get; set; }
        public virtual GeneralItem GeneralItem { get; set; }
        public virtual ICollection<GeneralCartItemAddon> GeneralCartItemAddons { get; set; }
    }
}
