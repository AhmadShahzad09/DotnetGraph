using Posts_graphql.Domain.Models;

namespace Posts_graphql.Infrastructure.Repository;

public interface IUserRepository
{
    Task<List<UserProfile>> GetAllUsers();
    Task<UserProfile> LoginUserAsync(string email);
    Task<UserProfile> RegisterUserAsync(UserProfile newUser);
    Task<bool?> IsUserExistsAsync(string email);
}
