using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class MailConfigration
    {
        public Guid Id { get; set; }
        public string Host { get; set; }
        public string Smtpemail { get; set; }
        public string Smtppassword { get; set; }
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
