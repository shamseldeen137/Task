using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class OrderItemAddon
    {
        public Guid Id { get; set; }
        public Guid? OrderItemId { get; set; }
        public Guid? AddonId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
