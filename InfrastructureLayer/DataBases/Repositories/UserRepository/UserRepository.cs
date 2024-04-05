using Microsoft.EntityFrameworkCore;
using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Context;

namespace Posts_graphql.Infrastructure.Repository;
public class UserRepository : IUserRepository
{
    protected readonly IDbContextFactory<PostGrapghQlDbContext> _contextFactory;
    protected readonly PostGrapghQlDbContext dbContext;

    public UserRepository(IDbContextFactory<PostGrapghQlDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        dbContext = contextFactory.CreateDbContext();
    }

    public async Task<UserProfile> LoginUserAsync(string email)
    {
        try
        {
            return await dbContext.User
                      .FirstOrDefaultAsync(user => user.Email == email  && user.FlgDelete == false);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }
    public async Task<UserProfile> RegisterUserAsync(UserProfile newUser)
    {
        try
        {
            dbContext.User.Add(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }
    public async Task<List<UserProfile>> GetAllUsers()
    {
        try
        {
            return await dbContext.User.Where(u => u.FlgDelete == false).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }

    public async Task<bool?> IsUserExistsAsync(string email)
    {
        try
        {
            var user = await dbContext.User.FirstOrDefaultAsync(u => u.Email == email && u.FlgDelete == false);
            if(user != null){
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }

}
