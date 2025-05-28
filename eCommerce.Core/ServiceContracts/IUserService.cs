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
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
        Task<UserDTO?> GetUserBuUserID(Guid userID); 
    }
}
