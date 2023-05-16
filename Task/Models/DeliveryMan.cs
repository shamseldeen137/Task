using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class DeliveryMan
    {
        public DeliveryMan()
        {
            DriverOrderChecks = new HashSet<DriverOrderCheck>();
        }

        public Guid Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int? Gender { get; set; }
        public string Nationality { get; set; }
        public string IdfrontImage { get; set; }
        public string IdbackImage { get; set; }
        public string CarLicenseFrontImage { get; set; }
        public string CarLicenseBackImage { get; set; }
        public string CarNumber { get; set; }
        public string CarBackPhoto { get; set; }
        public int? Status { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? StatusDate { get; set; }
        public Guid? UserId { get; set; }
        public int? DriverMoney { get; set; }
        public bool? IsOnline { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DriverOrderCheck> DriverOrderChecks { get; set; }
    }
}
