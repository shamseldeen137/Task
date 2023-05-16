
using System;
using System.Collections.Generic;
using System.Text;
using Task.Service.Enums;
namespace Task.Service.DTO.User
{
    public class UpdatingUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public string DeviceToken { get; set; }
      public UserTypesEnum Type { get; set; }
        public string Password { get; set; }
        public bool IsHasTempPassword { get; set; }
        public string TempPassword { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsBlocked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public int? Gender { get; set; }
        public double? Balance { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
