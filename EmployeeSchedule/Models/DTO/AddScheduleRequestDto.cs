using EmployeeSchedule.Models.Domain;

namespace EmployeeSchedule.Models.DTO
{
    public class AddScheduleRequestDto
    {

        public DateTime DateCheck { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
       
    }
}
