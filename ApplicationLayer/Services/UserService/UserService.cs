

using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Repository;
namespace Posts_graphql.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserProfile> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.LoginUserAsync(email);
            if (user != null)
            {
                if (GenericUtil.VerifyPassword(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<List<UserProfile>> GetAllUsers()
        {
            try
            {
                return await _userRepository.GetAllUsers();
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
                return await _userRepository.IsUserExistsAsync(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return null;
            }
        }


        public async Task<UserProfile> RegisterUserAsync(UserProfile newUser)
        {
            newUser.FlgDelete = false;
            if (newUser.Id == null)
            {
                newUser.AddedDateTime = DateTime.Now;
            }
            else
            {
                newUser.UpdatedDateTime = DateTime.Now;
            }
            newUser.Password = GenericUtil.HashPassword(newUser.Password);
            try
            {
                return await _userRepository.RegisterUserAsync(newUser);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return null;
            }
        }

    }
}
