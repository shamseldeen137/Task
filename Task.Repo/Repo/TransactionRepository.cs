
using Task.Data.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Task.Repo.IRepo;

namespace Task.Repo.Repo
{
    public class TransactionRepository : ITransactionRepository
    {
        DbContext Context;
        DbSet<Transaction> _transactionDbset;
        public TransactionRepository(TaskContext context)
        {
            Context = context;
            _transactionDbset = Context.Set<Transaction>();
        }
        public Transaction Create(Transaction entity)
        {
           
            entity.Id = Guid.NewGuid();
            return _transactionDbset.Add(entity).Entity;
        }

        public void Delete(Guid key)
        {
            var existedEntity = _transactionDbset.FirstOrDefault(item => item.Id == key);
            if (existedEntity == null)
                throw new Exception("Transaction Not Found");
            else
                existedEntity.IsDeleted = true;
        }

        public Transaction Get(Guid key)
        {
            var Transaction = _transactionDbset.AsNoTracking().FirstOrDefault(x => x.Id == key);
            if (Transaction == null)
                throw new Exception("Transaction Not Found");
            return Transaction;
        }

        public Transaction Get(Expression<Func<Transaction, bool>> expression)
        {
            if (expression == null)
                throw new Exception("Transaction Not Found");
            return _transactionDbset.AsNoTracking().Where(expression).FirstOrDefault();
        }

        public IEnumerable<Transaction> GetRange(Expression<Func<Transaction, bool>> expression = null)
        {
            IEnumerable<Transaction> Transactions;
            if (expression == null)
                Transactions = _transactionDbset.AsNoTracking().ToList();
            else
                Transactions = _transactionDbset.AsNoTracking().Where(expression).ToList();
            if(Transactions == null)
                throw new Exception("Not Found");
            return Transactions;
        }

        public IEnumerable<Transaction> GetRange(int pageNumber, byte pageSize)
        {
            var query = _transactionDbset.AsNoTracking().AsQueryable();
            var data = query.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
            return data;
        }

        public Transaction Update(Transaction entity)
        {
            var existedEntity = _transactionDbset.Any(item =>item.Id!=entity.Id&&( item.Id == entity.Id));
            if (existedEntity)
                throw new Exception("Transaction is already Exist");
            return _transactionDbset.Update(entity).Entity;
        }

       
    }
}
