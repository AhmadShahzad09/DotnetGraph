using Posts_graphql.Domain.Models;

namespace Posts_graphql.Infrastructure.Repository;

public interface IPostRepository
{
    Task<List<Post>> GetPost(int? id);
    Task<Post> AddEditPost(Post newPost);
   
}
