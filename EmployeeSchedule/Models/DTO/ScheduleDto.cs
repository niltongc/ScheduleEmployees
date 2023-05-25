using EmployeeSchedule.Models.Domain;

namespace EmployeeSchedule.Models.DTO
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime DateCheck { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }

    }
}
