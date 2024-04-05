using Microsoft.EntityFrameworkCore;
using Posts_graphql.Domain.Models;


namespace Posts_graphql.Infrastructure.Context
{
    public class PostGrapghQlDbContext : DbContext
    {
        public PostGrapghQlDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserProfile> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Notification> Notification { get; set; }


     }

}