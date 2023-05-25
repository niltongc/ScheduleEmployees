using EmployeeSchedule.Models.Domain;

namespace EmployeeSchedule.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule> CreateDateAsync(Schedule schedule);
        Task<List<Schedule?>> UpdateDateAsync(List<int> Ids, List<Schedule> schedule);
        Task<Schedule> GetById(int id);
        Task<List<Schedule>> GetByUserId(int userId);
    }
}
