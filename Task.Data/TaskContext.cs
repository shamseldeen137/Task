using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext()
        {
        }

        //public TaskContext(DbContextOptions<TaskContext> options)
        //    : base(options)
        //{
        //}
    }
}
