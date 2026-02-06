using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(string userName, string password);
    }
}