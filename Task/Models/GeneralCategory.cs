using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralCategory
    {
        public GeneralCategory()
        {
            GeneralItems = new HashSet<GeneralItem>();
            GeneralSubCategories = new HashSet<GeneralSubCategory>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? GeneralStoreId { get; set; }
        public int? Type { get; set; }

        public virtual GeneralStore GeneralStore { get; set; }
        public virtual ICollection<GeneralItem> GeneralItems { get; set; }
        public virtual ICollection<GeneralSubCategory> GeneralSubCategories { get; set; }
    }
}
