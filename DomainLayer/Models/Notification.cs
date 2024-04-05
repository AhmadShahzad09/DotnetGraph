namespace Posts_graphql.Domain.Models
{
    public class Notification : BaseIdentityEntity
    {
        public int NotificationTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
