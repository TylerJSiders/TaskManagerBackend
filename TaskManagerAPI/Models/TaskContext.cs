using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {

        }

        public DbSet<TaskItem> TodoItems { get; set; }
    }
}
