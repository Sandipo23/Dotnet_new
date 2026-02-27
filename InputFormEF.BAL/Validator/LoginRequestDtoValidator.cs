using FluentValidation;
using InputFormEF.BAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Validator
{
    internal class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("User name is required.");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
        }
    }
}