using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Service.DTO.User
{
    public class CreatingUserEmailDto
    {
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
