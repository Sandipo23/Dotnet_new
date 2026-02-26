using Azure;
using FluentValidation.Results;
using InputFormEF.BAL.ApplicationConstant;

using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Utilities
{
    public static class OutputDtoConverter
    {
        //for write
        public static OutputDto SetSuccess(string module, string operation)
        {
            string[] operations = { ApplicationConstant.Operation.Save, ApplicationConstant.Operation.Update, ApplicationConstant.Operation.Delete };
            bool exist = operations
                         .Contains(operation);
            if (!exist)
            {
                return SetFailed($"Invalid operation {operation}");
            }

            return new OutputDto
            {
                Status = Status.Success,
                Message = $"{module} {operation} successfully.",
            };
        }

        //for reading
        public static OutputDto<T> SetSuccess<T>(T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Success,
                Message = Message.Success,
                Data = data
            };
        }

        public static OutputDto SetFailed(String error)
        {
            return new OutputDto
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error
            };
        }

        public static OutputDto SetFailed(ValidationResult validationResult)
        {
            return new OutputDto
            {
                Status = Status.Failed,
                Message = Message.Failed,
                ValidationResult = validationResult
            };
        }

        //for reading
        public static OutputDto<T> SetFailed<T>(string error, T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Failed,
                Message = Message.Failed,
                Error = error,
                Data = data
            };
        }

        // for reading
        public static OutputDto<T> SetFailed<T>(ValidationResult validationResult, T data)
        {
            return new OutputDto<T>
            {
                Status = Status.Failed,
                Message = Message.Failed,
                ValidationResult = validationResult,
                Data = data
            };
        }
    }
}