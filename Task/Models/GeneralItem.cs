using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralItem
    {
        public GeneralItem()
        {
            GeneralAddOnsCategories = new HashSet<GeneralAddOnsCategory>();
            GeneralCartItems = new HashSet<GeneralCartItem>();
        }

        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public double Price { get; set; }
        public double DisCount { get; set; }
        public bool? IsOffer { get; set; }
        public bool? IsAdvertisment { get; set; }
        public double? OfferPrice { get; set; }
        public double? Kcal { get; set; }
        public bool? IsDeleted { get; set; }
        public string CoverPhoto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? GeneralSubCategoryId { get; set; }
        public int? Type { get; set; }
        public Guid? GeneralCategoryId { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual GeneralSubCategory GeneralSubCategory { get; set; }
        public virtual ICollection<GeneralAddOnsCategory> GeneralAddOnsCategories { get; set; }
        public virtual ICollection<GeneralCartItem> GeneralCartItems { get; set; }
    }
}
