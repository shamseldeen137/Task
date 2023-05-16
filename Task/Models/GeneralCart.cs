using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralCart
    {
        public GeneralCart()
        {
            GeneralCartItems = new HashSet<GeneralCartItem>();
        }

        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public string AddetionalData { get; set; }
        public double? TotalPrice { get; set; }
        public Guid? GeneralStoreId { get; set; }

        public virtual GeneralStore GeneralStore { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GeneralCartItem> GeneralCartItems { get; set; }
    }
}
