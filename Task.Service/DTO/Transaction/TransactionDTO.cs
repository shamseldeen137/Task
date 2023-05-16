

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Task.Service.Enums;
namespace Task.Service.DTO.User
{
    public class TransactionDTO
    {


        public Guid Id { get; set; }
        public string SendrId { get; set; }
        public string RecieverId { get; set; }
        public double Value { get; set; }
        public DateTime? CreatedAt { get; set; }
      

    }
}
