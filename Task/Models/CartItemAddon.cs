using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class CartItemAddon
    {
        public Guid Id { get; set; }
        public Guid? CartItemId { get; set; }
        public Guid? AddonId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual CartItem CartItem { get; set; }
    }
}
