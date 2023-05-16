


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task.Service.DTO.User
{
    public class CreatingUserDto
    {
      
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [Phone]
        public string Mobile { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.Upload)]
      
        [Display(Name = "Address")]
        public string Address { get; set; }
     
        [Display(Name = "Gender")]

        //  Male = 1,
        //Female = 2
        public int Gender { get; set; }



        //Admin = 1,
        //User = 2
        [Display(Name = "Type ")]
        public int Type { get; set; }




        public string Password { get; set; }
        public string DeviceToken { get; set; }
        public string Token { get; set; }
    }
}
