using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralSubCategory
    {
        public GeneralSubCategory()
        {
            GeneralItems = new HashSet<GeneralItem>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? GeneralCategoryId { get; set; }
        public int? Type { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual ICollection<GeneralItem> GeneralItems { get; set; }
    }
}
