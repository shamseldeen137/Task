using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class MarketCategory
    {
        public MarketCategory()
        {
            MarketSubCategories = new HashSet<MarketSubCategory>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<MarketSubCategory> MarketSubCategories { get; set; }
    }
}
