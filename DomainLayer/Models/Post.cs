namespace Posts_graphql.Domain.Models
{
    public class Post : BaseIdentityEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
