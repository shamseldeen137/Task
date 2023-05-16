using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class UserNotification
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }

        public virtual Notification Notification { get; set; }
        public virtual User User { get; set; }
    }
}
