using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUsersRepositotry
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailOrPassword(string? email, string? password);
        Task<ApplicationUser?> GetUserByUserID(Guid? userID);
    }
}
