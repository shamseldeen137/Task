using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class DriverOrderCheck
    {
        public Guid Id { get; set; }
        public Guid? DriverId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? PackageId { get; set; }
        public int? Type { get; set; }
        public int? AcceptRefuse { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual DeliveryMan Driver { get; set; }
        public virtual Order Order { get; set; }
        public virtual Package Package { get; set; }
    }
}
