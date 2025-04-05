using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUserService
    {
        private readonly IUsersRepositotry usersRepositotry;

        public UsersService(IUsersRepositotry usersRepositotry) 
        {
            this.usersRepositotry = usersRepositotry;
        }
        public async Task<AuhenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await usersRepositotry.GetUserByEmailOrPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;    
            }

            return new AuhenticationResponse
                (user.UserID, user.Email, user.PersonName, user.Gender,"token",Success:true);
        }

        public async Task<AuhenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),

            };
            
           ApplicationUser? registeredUser = await usersRepositotry.AddUser(user);

            if (registeredUser != null)
            {
                return null;
            }

            return new AuhenticationResponse
                (registeredUser.UserID,registeredUser.Email,registeredUser.PersonName,registeredUser.Gender,
                "token",Success:true);
        }
    }
}
