using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal static class DateUtility
    {
        public static string FormatDate(this DateTime date, string format = Constants.Format)
        {
            return date.ToString(format);
        }
    }
}