using System;
using System.Collections.Generic;

#nullable disable

namespace Task.Models
{
    public partial class GeneralCartItemAddon
    {
        public Guid Id { get; set; }
        public Guid? GeneralCartItemId { get; set; }
        public Guid? GeneralAddonId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual GeneralAddOn GeneralAddon { get; set; }
        public virtual GeneralCartItem GeneralCartItem { get; set; }
    }
}
