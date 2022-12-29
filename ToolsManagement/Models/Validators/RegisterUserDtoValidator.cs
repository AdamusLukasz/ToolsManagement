using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Data.Context;

namespace ToolsManagement.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(ToolsManagementDbContext dbContext)
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(12);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(12);

            RuleFor(p => p.Password).MaximumLength(6);
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password);

            // TODO : Validations should be for FirstName+LastName not just one of them
            RuleFor(p => p.FirstName).Custom((value, context) =>
                {
                    var userExist = dbContext.Users.Any(f => f.FirstName == value);
                    if (userExist)
                    {
                        context.AddFailure("FirstNam", "That user is taken.");
                    }
                });
        }
    }
}
