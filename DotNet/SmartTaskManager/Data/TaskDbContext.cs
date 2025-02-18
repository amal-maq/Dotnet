using Microsoft.EntityFrameworkCore;
using SmartTaskManager.Models;

namespace SmartTaskManager.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskDb> Tasks { get; set; }
    }
}
