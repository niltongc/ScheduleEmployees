using EmployeeSchedule.Models.DTO;
using FluentValidation;

namespace EmployeeSchedule.Models.Validation
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequestDto>
    {
        public UpdateUserValidator() 
        {
            RuleFor(u => u.Name)
               .NotEmpty()
               .NotNull()
               .Length(3, 100)
               .WithMessage("'Name' can not be empty and must have range 3 to 100 chars");
            RuleFor(u => u.Email)
            .EmailAddress()
                .WithMessage("‘Email’ is not a valid email address");
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .Length(3, 32)
                .WithMessage("'Password' can not be empty and must have range 3 to 32 chars");
        }
    }
}
