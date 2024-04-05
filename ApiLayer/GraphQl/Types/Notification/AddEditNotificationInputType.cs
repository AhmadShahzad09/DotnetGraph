using Posts_graphql.Domain.Models;

public class AddEditNotificationInputType : InputObjectType<Notification>
{
    protected override void Configure(IInputObjectTypeDescriptor<Notification> descriptor)
    {
        descriptor.Field(t => t.NotificationTypeId).Type<NonNullType<StringType>>().Name("NotificationTypeId");
        descriptor.Field(t => t.Title).Type<NonNullType<StringType>>().Name("Title");
        descriptor.Field(t => t.Description).Type<NonNullType<StringType>>().Name("Description");
      
    }
}
