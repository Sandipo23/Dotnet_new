using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputForm.DAL;

namespace InputForm.BAL
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            bool success = await _loginRepository.LoginAsync(userName, password);
            return success;
        }
    }
}