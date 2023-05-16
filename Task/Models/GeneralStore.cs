using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralStore
    {
        public GeneralStore()
        {
            GeneralCarts = new HashSet<GeneralCart>();
            GeneralCategories = new HashSet<GeneralCategory>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public bool? IsDeleted { get; set; }
        public string CoverPhoto { get; set; }
        public string Phone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public string Logo { get; set; }
        public double? Rate { get; set; }
        public double? MinOrderLimit { get; set; }
        public string DeliveryType { get; set; }
        public double? DeliveryFee { get; set; }
        public double? NumberOfRates { get; set; }
        public double? OrderCoins { get; set; }
        public double? DeliveryTimeTo { get; set; }
        public double? DeliveryTimeFrom { get; set; }
        public Guid? GeneralStoreTypeId { get; set; }
        public int? Type { get; set; }

        public virtual GeneralStoreType GeneralStoreType { get; set; }
        public virtual ICollection<GeneralCart> GeneralCarts { get; set; }
        public virtual ICollection<GeneralCategory> GeneralCategories { get; set; }
    }
}
