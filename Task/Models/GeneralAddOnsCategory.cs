using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralAddOnsCategory
    {
        public GeneralAddOnsCategory()
        {
            GeneralAddOns = new HashSet<GeneralAddOn>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public bool? IsDeleted { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? ProductId { get; set; }

        public virtual GeneralItem Product { get; set; }
        public virtual ICollection<GeneralAddOn> GeneralAddOns { get; set; }
    }
}
