using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Photo { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? StoreId { get; set; }

        public virtual Restaurant Store { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
