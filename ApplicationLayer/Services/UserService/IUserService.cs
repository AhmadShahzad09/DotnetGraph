

using Posts_graphql.Domain.Models;
namespace Posts_graphql.Application.Services
{
    public interface IUserService
    {
        Task<List<UserProfile>> GetAllUsers();
        Task<UserProfile> LoginUserAsync(string email, string password);
        Task<UserProfile> RegisterUserAsync(UserProfile userProfile);
        Task<bool?> IsUserExistsAsync(string email);
    }

}
