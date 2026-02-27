using FluentValidation;
using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Interfaces;
using InputFormEF.BAL.Utilities;
using InputFormEF.DAL;

namespace InputFormEF.BAL.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IValidator<LoginRequestDto> _loginValidator;

        public LoginService(ILoginRepository loginRepository, IValidator<LoginRequestDto> loginValidator)
        {
            _loginRepository = loginRepository;
            _loginValidator = loginValidator;
        }

        public async Task<OutputDto> LoginAsync(LoginRequestDto request)
        {
            try
            {
                var validationResult = await _loginValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed(validationResult);

                bool success = await _loginRepository.LoginAsync(request.UserName, request.Password);
                if (success)
                    return OutputDtoConverter.SetSuccess();

                return OutputDtoConverter.SetFailed("Invalid username or password");
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }
    }
}