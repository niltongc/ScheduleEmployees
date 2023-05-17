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

        public async Task<List<Schedule>> GetByUserId(int userId, int mouth)
        {
            var schedulesByMouth = await dbContext.Schedules
                .Where(x => x.UserId == userId && x.DateCheck.Month == mouth)
                .ToListAsync();

            return schedulesByMouth;
        }


        public async Task<Schedule?> UpdateDateAsync(int Id, Schedule schedule)
        {
            var existingSchedule = await dbContext.Schedules.FirstOrDefaultAsync(x => x.Id == Id);


            if (existingSchedule == null)
            {
                return null;
            }

            
            
            existingSchedule.DateCheck = schedule.DateCheck;

           


            await dbContext.SaveChangesAsync();

            return existingSchedule;
        }


    }
}
