using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class OrderImage
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid? PackageId { get; set; }
        public Guid? OrderId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Order Order { get; set; }
        public virtual Package Package { get; set; }
    }
}
