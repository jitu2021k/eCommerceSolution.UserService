using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts
{
    public interface IUserService
    {
        /// <summary>
        /// Method to Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuhenticationResponse?> Login(LoginRequest loginRequest);
        Task<AuhenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
