using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralStoreType
    {
        public GeneralStoreType()
        {
            GeneralStores = new HashSet<GeneralStore>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public int? Type { get; set; }

        public virtual ICollection<GeneralStore> GeneralStores { get; set; }
    }
}
