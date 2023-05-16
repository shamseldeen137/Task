using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class PackageProduct
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public Guid? PackageId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Package Package { get; set; }
    }
}
