using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Data.Models
{
    public partial class User
    {
        public User()
        {
            TransactionRecievers = new HashSet<Transaction>();
            TransactionSendrs = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public double? Balance { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public string Token { get; set; }
        public bool IsDeleted { get; set; }
        public int Type { get; set; }
        public string DeviceToken { get; set; }
        public bool IsHasTempPassword { get; set; }
        public string TempPassword { get; set; }
        public bool? IsBlocked { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Transaction> TransactionRecievers { get; set; }
        public virtual ICollection<Transaction> TransactionSendrs { get; set; }
    }
}
