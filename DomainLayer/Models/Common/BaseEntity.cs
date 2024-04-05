namespace Posts_graphql.Domain.Models
{
    public class BaseEntity
    {
        public DateTime? AddedDateTime { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? FlgDelete { get; set; }
    }
}
