using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDdelivery.Web.Models.APIs.VMs
{
    public class ConfirmForgotPasswordVM
    {
        public string Phone { get; set; }
        public string Code { get; set; }
    }
}
