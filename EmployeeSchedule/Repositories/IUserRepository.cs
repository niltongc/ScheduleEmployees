using EmployeeSchedule.Models.Domain;

namespace EmployeeSchedule.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByEmailAsync(string user);
        Task<List<User>> GetAllAsync();
        Task<User?> UpdateUserAsync(string email,User user);
        Task<User?> DeleteUserAsync(int id);
    }
}
