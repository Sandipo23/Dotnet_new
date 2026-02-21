using FluentValidation;
using InputFormEF.BAL.Dto;

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Validator
{
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

            RuleFor(x => x.CourseId)
            .NotEmpty()
            .WithMessage("Course is required.");

            RuleFor(x => x.Agree)
            .Must(x => x == true)          //for bool must is needed
            .WithMessage("Agree is required.");

            RuleFor(x => x.DOB)
            .NotEmpty()
            .WithMessage("DOB is required.");

            RuleFor(x => x.HobbyIds)
            .NotEmpty()
            .WithMessage("Hobby is required.");
        }
    }
}