namespace Posts_graphql.Domain.Models
{
    public class UserProfile : BaseIdentityEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhNo { get; set; }
    
    }
}
