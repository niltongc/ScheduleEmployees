using EmployeeSchedule.Data;
using EmployeeSchedule.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSchedule.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ScheduleDbContext dbContext;

        public SQLUserRepository(ScheduleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllAsync() => 
            await dbContext.Users
                .AsNoTracking()
                .ToListAsync();

        public async Task<User?> GetByEmailAsync(string user) => 
            await dbContext.Users.FirstOrDefaultAsync(x => x.Email == user);

        public async Task<User> UpdateUserAsync(string email, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (existingUser == null) 
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            await dbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
