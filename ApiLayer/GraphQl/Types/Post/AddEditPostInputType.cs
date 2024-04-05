using Posts_graphql.Domain.Models;

public class AddEditPostInputType : InputObjectType<Post>
{
    protected override void Configure(IInputObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Field(t => t.Title).Type<NonNullType<StringType>>().Name("Title");
        descriptor.Field(t => t.Description).Type<NonNullType<StringType>>().Name("Description");
      
    }
}
