using System;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using InputFormEF.BAL.Enums;

namespace InputFormEF.BAL.Dto
{
    public class OutputDto
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string Error { get; set; }
    }

    public class OutputDto<T> : OutputDto
    {
        public T Data { get; set; }
    }
}