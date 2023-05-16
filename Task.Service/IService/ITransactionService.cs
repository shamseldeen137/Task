using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Service.DTO.User;
using Task.Service.Enums;

namespace Task.Service.IService
{
    public interface ITransactionService
    {
        TransactionDTO Get(Guid id);
      
        IEnumerable<TransactionDTO> GetAll();
       
        UpdatedUserDto Update(TransactionDTO updatingUserDto);

        TransactionDTO Create(TransactionDTO creatingUserDto);
        void Delete(Guid id);
    
        //void UpdateUserCoins(Guid userId, double storecoins);
    }
}
