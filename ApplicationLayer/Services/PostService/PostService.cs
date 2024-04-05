

using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Repository;
namespace Posts_graphql.Application.Services
{
    public class PostService : IPostService
    {
        private readonly PostRepository _PostRepository;

        public PostService(PostRepository PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public async Task<List<Post>> GetPost(int? postId)
        {
            try
            {
                return await _PostRepository.GetPost(postId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return null;
            }
        }
        public async Task<Post> AddEditPost(Post newPost)
        {
            try
            {
                if (newPost.Id == null)
                {
                    newPost.FlgDelete = false;
                    newPost.AddedDateTime = DateTime.Now;
                }
                else
                {
                    newPost.UpdatedDateTime = DateTime.Now;
                }
                return await _PostRepository.AddEditPost(newPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return null;
            }
        }



    }
}
