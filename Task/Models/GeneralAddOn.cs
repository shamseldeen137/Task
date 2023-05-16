using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralAddOn
    {
        public GeneralAddOn()
        {
            GeneralCartItemAddons = new HashSet<GeneralCartItemAddon>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public double Price { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? GeneralAddOnCategoryId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual GeneralAddOnsCategory GeneralAddOnCategory { get; set; }
        public virtual ICollection<GeneralCartItemAddon> GeneralCartItemAddons { get; set; }
    }
}
