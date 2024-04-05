using Microsoft.EntityFrameworkCore;
using Posts_graphql.Domain.Models;
using Posts_graphql.Infrastructure.Context;

namespace Posts_graphql.Infrastructure.Repository;
public class PostRepository : IPostRepository
{
    protected readonly IDbContextFactory<PostGrapghQlDbContext> _contextFactory;
    protected readonly PostGrapghQlDbContext dbContext;

    public PostRepository(IDbContextFactory<PostGrapghQlDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
        dbContext = contextFactory.CreateDbContext();
    }

    public async Task<List<Post>> GetPost(int? postId)
    {
        try
        {
            if (postId == null)
            {
                return await dbContext.Post.Where(p => p.FlgDelete == false).ToListAsync();
            }
            else
            {
                return await dbContext.Post.Where(p => p.FlgDelete == false && p.Id == postId).ToListAsync();
            }

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
                dbContext.Post.Add(newPost);
                await dbContext.SaveChangesAsync();

            }
            else
            {
                var existingPost = await dbContext.Post.FirstOrDefaultAsync(p => p.Id == newPost.Id && p.FlgDelete == false);
                newPost.AddedBy = existingPost.AddedBy;
                newPost.AddedDateTime = existingPost.AddedDateTime;
                if(newPost.FlgDelete != true){
                    newPost.FlgDelete = false;
                }
                 dbContext.Entry(existingPost).CurrentValues.SetValues(newPost);
                // dbContext.Entry(newPost).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            return newPost;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while logging in: {ex.Message}");
            return null;
        }
    }


}
