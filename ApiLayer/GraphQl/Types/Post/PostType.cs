using HotChocolate.Types;
using posts_graphql.api.Types;
using Posts_graphql.Application.Services;
using Posts_graphql.Domain.Models;

namespace posts_graphql.api.Query
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
           descriptor.Field(p => p.Id)
                .Type<NonNullType<IntType>>()
                .Name("id")
                .Description("The unique identifier of the user.");
            
           
            descriptor.Field(p => p.Title)
                .Type<NonNullType<StringType>>()
                .Name("Title")
                .Description("The Title of the user.");

            descriptor.Field(p => p.Description)
                .Type<NonNullType<StringType>>()
                .Name("Description")
                .Description("The Description of the user.");
             descriptor.Field(p => p.AddedBy)
                .Type<NonNullType<StringType>>()
                .Name("AddedBy")
                .Description("user id who added this user.");
            descriptor.Field(p => p.AddedDateTime)
                .Type<NonNullType<StringType>>()
                .Name("AddedDateTime")
                .Description("The AddedDateTime of the user.");
            descriptor.Field(p => p.UpdatedBy)
                .Type<NonNullType<StringType>>()
                .Name("UpdatedBy")
                .Description("The user id who updatedthis user.");
            descriptor.Field(p => p.UpdatedDateTime)
                .Type<NonNullType<StringType>>()
                .Name("UpdatedDateTime")
                .Description("The UpdatedDateTime of the user.");
            descriptor.Field(p => p.FlgDelete)
                .Type<NonNullType<StringType>>()
                .Name("FlgDelete")
                .Description("FlgDelete is a boolean to represent state of user deleted or not.");
           
            descriptor.Field<GetPostResolver>(x => x.GetPost(default));
        }
    }

    public class GetPostResolver
    {
        private readonly PostService _PostService;

        public GetPostResolver(PostService PostService)
        {
            _PostService = PostService;
        }
        public async Task<List<Post>> GetPost(int postId)
        {
            return await _PostService.GetPost(postId);
        }

    }



}
