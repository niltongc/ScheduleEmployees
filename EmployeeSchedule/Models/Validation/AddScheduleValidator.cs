using EmployeeSchedule.Models.DTO;
using FluentValidation;

namespace EmployeeSchedule.Models.Validation
{
    public class AddScheduleValidator : AbstractValidator<AddScheduleRequestDto>
    {
        public AddScheduleValidator()
        {
            RuleFor(s => s.UserId).NotEmpty().WithMessage("Field Required");
            RuleFor(s => s.DateCheck).LessThan(DateTime.UtcNow).WithMessage("Incorrect Date");
        }
    }
}
