using EmployeeSchedule.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSchedule.Data
{
    public class ScheduleDbContext: DbContext
    {
        public ScheduleDbContext(DbContextOptions  dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
