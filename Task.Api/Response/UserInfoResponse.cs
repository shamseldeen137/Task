
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Api.Resopnse
{
    public class UserInfoResponse
    {
        public object User { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
