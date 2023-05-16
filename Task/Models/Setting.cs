using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class Setting
    {
        public Guid Id { get; set; }
        public string FacebookLink { get; set; }
        public string WhatsappLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstgramLink { get; set; }
        public string MailLink { get; set; }
        public string PlayStoreLink { get; set; }
        public string AppStoreLink { get; set; }
        public string SnapShotLink { get; set; }
        public string AboutUsAr { get; set; }
        public string AboutUsEn { get; set; }
        public string Version { get; set; }
        public string TermesAndConditions { get; set; }
        public string PrivacyPolicy { get; set; }
    }
}
