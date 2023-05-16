
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
    public class UserRepository : IUserRepository
    {
        DbContext Context;
        DbSet<User> _userDbset;
        public UserRepository(TaskContext context)
        {
            Context = context;
            _userDbset = Context.Set<User>();
        }
        public User Create(User entity)
        {
            var oldEntity = _userDbset.Where(user => user.Mobile.ToLower() == entity.Mobile.ToLower());

            if (oldEntity != null)
                if (oldEntity.Count()>0)
                    throw new Exception("Phone is Already Exist");
            entity.Id = Guid.NewGuid();
            return _userDbset.Add(entity).Entity;
        }

        public void Delete(Guid key)
        {
            var existedEntity = _userDbset.FirstOrDefault(item => item.Id == key);
            if (existedEntity == null)
                throw new Exception("User Not Found");
            else
                existedEntity.IsDeleted = true;
        }

        public User Get(Guid key)
        {
            var user = _userDbset.AsNoTracking().FirstOrDefault(x => x.Id == key);
            if (user == null)
                throw new Exception("User Not Found");
            return user;
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            if (expression == null)
                throw new Exception("User Not Found");
            return _userDbset.AsNoTracking().Where(expression).FirstOrDefault();
        }

        public IEnumerable<User> GetRange(Expression<Func<User, bool>> expression = null)
        {
            IEnumerable<User> users;
            if (expression == null)
                users = _userDbset.AsNoTracking().ToList();
            else
                users = _userDbset.AsNoTracking().Where(expression).ToList();
            if(users == null)
                throw new Exception("Not Found");
            return users;
        }

        public IEnumerable<User> GetRange(int pageNumber, byte pageSize)
        {
            var query = _userDbset.AsNoTracking().AsQueryable();
            var data = query.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
            return data;
        }

        public User Update(User entity)
        {
            var existedEntity = _userDbset.Any(item =>item.Id!=entity.Id&&( item.Mobile == entity.Mobile));
            if (existedEntity)
                throw new Exception("User is already Exist");
            return _userDbset.Update(entity).Entity;
        }

        public void UpdateUserBalance(Guid userId, double storecoins)
        {
            _userDbset.FirstOrDefault(c => c.Id == userId).Balance = storecoins;
        }
    }
}
