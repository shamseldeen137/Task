using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class T
    {
        public Guid Id { get; set; }
        public string Namear { get; set; }
        public string NameEn { get; set; }
        public string CoverPhoto { get; set; }
        public double? Rate { get; set; }
        public double? NumberOfRates { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public double? OrderCoins { get; set; }
        public double? DeliveryFee { get; set; }
        public int Type { get; set; }
        public double? DeliveryTimeTo { get; set; }
        public double? DeliveryTimeFrom { get; set; }
    }
}
