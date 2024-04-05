namespace posts_graphql.api.Types;

using HotChocolate.Types;
using Posts_graphql.Domain.Models;

public class NotificationType : ObjectType<Notification>
    {
        protected override void Configure(IObjectTypeDescriptor<Notification> descriptor)
        {
            descriptor.Field(p => p.Id)
                .Type<NonNullType<IntType>>()
                .Name("id")
                .Description("The unique identifier of the Notification.");
            
           
            descriptor.Field(p => p.Title)
                .Type<NonNullType<StringType>>()
                .Name("Title")
                .Description("The Title of the Notification.");

            descriptor.Field(p => p.Description)
                .Type<NonNullType<StringType>>()
                .Name("Description")
                .Description("The Description of the Notification.");
             descriptor.Field(p => p.AddedBy)
                .Type<NonNullType<StringType>>()
                .Name("AddedBy")
                .Description("User id who added this Notification.");
            descriptor.Field(p => p.AddedDateTime)
                .Type<NonNullType<StringType>>()
                .Name("AddedDateTime")
                .Description("The AddedDateTime of the Notification.");
            descriptor.Field(p => p.UpdatedBy)
                .Type<NonNullType<StringType>>()
                .Name("UpdatedBy")
                .Description("The Notification id who updatedthis Notification.");
            descriptor.Field(p => p.UpdatedDateTime)
                .Type<NonNullType<StringType>>()
                .Name("UpdatedDateTime")
                .Description("The UpdatedDateTime of the Notification.");
            descriptor.Field(p => p.FlgDelete)
                .Type<NonNullType<StringType>>()
                .Name("FlgDelete")
                .Description("FlgDelete is a boolean to represent state of Notification deleted or not.");
       
        }
    }

