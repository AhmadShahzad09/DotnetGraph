

using Posts_graphql.Domain.Models;
namespace Posts_graphql.Application.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPost(int? postId);
        Task<Post> AddEditPost(Post newPost);
    }

}
