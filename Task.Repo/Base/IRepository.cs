using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Task.Repo.Base
{
    public interface IRepository<Entity, PrimaryKey>
    {
        Entity Get(Guid key);
        Entity Get(Expression<Func<Entity, bool>> expression = null);
        IEnumerable<Entity> GetRange(Expression<Func<Entity, bool>> expression = null);
       
        IEnumerable<Entity> GetRange(int pageNumber, byte pageSize);
   
     
        Entity Create(Entity entity);
        void Delete(Guid key);
        Entity Update(Entity entity);
       
    }
}
