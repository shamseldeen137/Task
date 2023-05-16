using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class ChargeAddress
    {
        public ChargeAddress()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Address { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Type { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
