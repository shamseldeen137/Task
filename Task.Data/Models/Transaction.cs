using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Data.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? SendrId { get; set; }
        public Guid? RecieverId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User Reciever { get; set; }
        public virtual User Sendr { get; set; }
    }
}
