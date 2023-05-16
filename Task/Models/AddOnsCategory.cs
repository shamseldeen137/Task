using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class AddOnsCategory
    {
        public AddOnsCategory()
        {
            Addons = new HashSet<Addon>();
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

        public virtual Product Product { get; set; }
        public virtual ICollection<Addon> Addons { get; set; }
    }
}
