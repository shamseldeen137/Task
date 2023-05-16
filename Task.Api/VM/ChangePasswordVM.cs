using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HDdelivery.Web.Models.APIs.VMs
{
    public class ChangePasswordVM
    {
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        [Display(Name = "New Password")]
        public string newPassword { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "Confirm New Password")]
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "Your New password and confirm new password do not match")]
        public string confirmPassword { get; set; }
    }
}
