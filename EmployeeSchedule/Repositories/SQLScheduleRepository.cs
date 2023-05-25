using EmployeeSchedule.Data;
using EmployeeSchedule.Models.Domain;
using EmployeeSchedule.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeSchedule.Repositories
{
    public class SQLScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleDbContext dbContext;

        public SQLScheduleRepository(ScheduleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Schedule> CreateDateAsync(Schedule schedule)
        {

            await dbContext.Schedules.AddAsync(schedule);
            await dbContext.SaveChangesAsync();
            
            return schedule;
        }

        public async Task<Schedule> GetById(int id)
        {
            var daySchedule = await dbContext.Schedules.FirstOrDefaultAsync(x => x.Id == id);

            if (daySchedule == null)
            {
                return null;
            }
            return daySchedule;
        }

        public async Task<List<Schedule>> GetByUserId(int userId)
        {
            var schedulesByMouth = await dbContext.Schedules
                .Where(x => x.UserId == userId && x.DateCheck.Month == DateTime.UtcNow.Month)
                .ToListAsync();

            return schedulesByMouth;
        }

        //public async Task<List<Schedule>> GetByUserId(int userId, int mouth)
        //{
        //    var schedulesByMouth = await dbContext.Schedules
        //        .Where(x => x.UserId == userId && x.DateCheck.Month == mouth)
        //        .ToListAsync();

        //    return schedulesByMouth;
        //}


        public async Task<List<Schedule?>> UpdateDateAsync(List<int> Ids, List<Schedule> schedule)
        {
            var existingSchedule = await dbContext.Schedules.Where(x => Ids.Contains(x.Id)).ToListAsync();


            if (existingSchedule.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < existingSchedule.Count; i++)
            {
                existingSchedule[i].DateCheck = schedule[i].DateCheck;
            
            }


            await dbContext.SaveChangesAsync();

            return existingSchedule;
        }

       
    }
}
