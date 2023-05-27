using EmployeeSchedule.Models.DTO;
using FluentValidation;
using System.Data;
using System.Net;

namespace EmployeeSchedule.Models.Validation
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequestDto>
    {
        public AddUserRequestValidator() 
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .Length(3,100)
                .WithMessage("'Name' can not be empty and must have range 3 to 100 chars");
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("‘Email’ is not a valid email address");
            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .Length(3, 32)
                .WithMessage("'Password' can not be empty and must have range 3 to 32 chars");
            RuleFor(u => u.Role)
                .Must(role => role == "admin" || role == "employee")
                .WithMessage("'Role' must be 'admin' or 'employee'");
        }
    }
}
