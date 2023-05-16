using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Faq
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
