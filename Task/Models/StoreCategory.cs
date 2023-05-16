using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class StoreCategory
    {
        public StoreCategory()
        {
            StoreItems = new HashSet<StoreItem>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
