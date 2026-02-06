using InputFormEF.BAL.Interfaces;
using InputFormEF.DAL;

namespace InputFormEF.BAL.Services
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