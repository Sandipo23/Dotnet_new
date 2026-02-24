using FluentValidation;
using InputFormEF.BAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Validator
{
    public class SaveImageRequestValidator : AbstractValidator<SaveImageRequest>
    {
        public SaveImageRequestValidator()
        {
            RuleFor(x => x.Source)
           .NotEqual(x => x.Destination)
           .When(x => !String.IsNullOrEmpty(x.Source?.Trim()))
           .WithMessage("Source and destination cannot be same.");
        }
    }
}