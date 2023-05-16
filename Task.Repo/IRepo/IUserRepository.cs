using Task.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repo.Base;

namespace Task.Repo.IRepo
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        void UpdateUserBalance(Guid userId, double storecoins);
    }
}
