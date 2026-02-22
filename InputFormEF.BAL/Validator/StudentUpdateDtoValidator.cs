using FluentValidation;
using InputFormEF.BAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Validator
{
    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            Include(x => new StudentCreateDtoValidator());

            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        }
    }
}