using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Addon
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public double Price { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? AddonsCategoryId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AddOnsCategory AddonsCategory { get; set; }
    }
}
