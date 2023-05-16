
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Service.DTO.User;

namespace Task.Api.Resopnse
{
    public class TransactionResponse
    {
        public List<TransactionDTO> data { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
