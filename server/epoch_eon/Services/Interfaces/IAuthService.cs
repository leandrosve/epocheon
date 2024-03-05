using Prueba.Models.DTOs.Auth;

namespace Prueba.Services.Interfaces
{
    public interface IAuthService
    {
        public void SignUp(SignupDataDTO signupData);

        public AdminSessionDTO? LogIn(LoginRequestDTO loginRequest);

    }
}
