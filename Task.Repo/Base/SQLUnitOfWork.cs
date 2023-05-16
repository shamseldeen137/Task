//using Microsoft.EntityFrameworkCore;
using Task.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Task.Repo.Base
{
    public class SQLUnitOfWork  : IUnitOfWork, IDisposable
    {
        TaskContext _context;
        public SQLUnitOfWork(TaskContext context)
        {
            _context = context;
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
