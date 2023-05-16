using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Notification
    {
        public Notification()
        {
            UserNotifications = new HashSet<UserNotification>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NotificationStatus { get; set; }
        public int NotificationType { get; set; }
        public string NavigationUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }
    }
}
