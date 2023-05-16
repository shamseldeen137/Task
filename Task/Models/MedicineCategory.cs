using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class MedicineCategory
    {
        public MedicineCategory()
        {
            Medicines = new HashSet<Medicine>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? StoreId { get; set; }

        public virtual Pharmacy Store { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
