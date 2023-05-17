namespace EmployeeSchedule.Models.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateCheck { get; set; } = DateTime.UtcNow;
        public bool IsLogin { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
