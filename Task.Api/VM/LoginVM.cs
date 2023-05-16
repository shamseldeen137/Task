using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDdelivery.Web.Models.APIs.VMs
{
    public class LoginVM
    {
        public string Phone { get; set; }
        public string Password { get; set; }
        public string DeviceToken { get; set; }
    }
}
