using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUserService
    {
        private readonly IUsersRepositotry usersRepositotry;
        private readonly IMapper mapper;

        public UsersService(IUsersRepositotry usersRepositotry,IMapper mapper) 
        {
            this.usersRepositotry = usersRepositotry;
            this.mapper = mapper;
        }

        public async Task<UserDTO?> GetUserBuUserID(Guid userID)
        {
            ApplicationUser? applicationUser =  await usersRepositotry.GetUserByUserID(userID);
            UserDTO userDTO =  mapper.Map<UserDTO>(applicationUser);
            return userDTO;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await usersRepositotry.GetUserByEmailOrPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;    
            }

            //return new AuthenticationResponse
            //    (user.UserID, user.Email, user.PersonName, user.Gender,"token",Success:true);

            return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token="token"};
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            //ApplicationUser user = new ApplicationUser()
            //{
            //    PersonName = registerRequest.PersonName,
            //    Email = registerRequest.Email,
            //    Password = registerRequest.Password,
            //    Gender = registerRequest.Gender.ToString(),

            //};

           ApplicationUser user  = mapper.Map<ApplicationUser>(registerRequest);
            
           ApplicationUser? registeredUser = await usersRepositotry.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }

            //return new AuthenticationResponse
            //    (registeredUser.UserID,registeredUser.Email,registeredUser.PersonName,registeredUser.Gender,
            //    "token",Success:true);

            return mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };

        }
    }
}
