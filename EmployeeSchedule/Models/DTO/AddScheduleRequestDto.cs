using EmployeeSchedule.Models.Domain;

namespace EmployeeSchedule.Models.DTO
{
    public class AddScheduleRequestDto
    {

        public DateTime DateCheck { get; set; } = DateTime.UtcNow;
        public bool IsLogin { get; set; }
        public int UserId { get; set; }
       
    }
}
