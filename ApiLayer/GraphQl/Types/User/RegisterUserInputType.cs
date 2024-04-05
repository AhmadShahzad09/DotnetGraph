using Posts_graphql.Domain.Models;

public class RegisterUserInputType : InputObjectType<UserProfile>
{
    protected override void Configure(IInputObjectTypeDescriptor<UserProfile> descriptor)
    {
        descriptor.Field(t => t.Email).Type<NonNullType<StringType>>().Name("email");
        descriptor.Field(t => t.Password).Type<NonNullType<StringType>>().Name("password");
        descriptor.Field(t => t.FirstName).Type<StringType>().Name("firstName");
        descriptor.Field(t => t.LastName).Type<StringType>().Name("lastName");
        descriptor.Field(t => t.PhNo).Type<StringType>().Name("phNo");
        descriptor.Field(t => t.AddedBy).Type<StringType>().Name("AddedBy");
    }
}
