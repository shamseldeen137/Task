using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class MarketSubCategory
    {
        public MarketSubCategory()
        {
            Items = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? StoreId { get; set; }

        public virtual MarketCategory Store { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
