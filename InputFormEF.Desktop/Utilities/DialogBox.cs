using InputFormEF.BAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message = InputFormEF.BAL.ApplicationConstant.Message;

namespace InputFormEF.Desktop.Utilities
{
    public static class DialogBox

    {
        public static void SuccessAlert(string message, string caption = Message.Success)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void FailureAlert(string error, string caption = Message.Failed)
        {
            MessageBox.Show(error, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FailureAlert(OutputDto result)
        {
            if (result.ValidationResult != null)
            {
                var errors = result
                             .ValidationResult
                             .Errors
                             .Select(x => x.ErrorMessage)
                             .ToList();
                string error = String.Join(Environment.NewLine, errors);
                MessageBox.Show(error, result.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(result.Error, result.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}