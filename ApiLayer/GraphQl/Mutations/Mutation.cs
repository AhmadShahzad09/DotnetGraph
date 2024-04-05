using Posts_graphql.Domain.Models;
using posts_graphql.api.Types;
using Posts_graphql.Application.Services;

public class Mutation
{

     private readonly UserService _UserService;
    private readonly PostService _PostService;
    private readonly NotificationService _NotificationService;

    public Mutation(UserService userService ,  PostService postService ,  NotificationService notificationService )
    {
        _UserService = userService;
        _PostService = postService;
        _NotificationService = notificationService;
    }

    public async Task<UserProfile> RegisterUserAsync(UserProfile newUser)
    {
        return await _UserService.RegisterUserAsync(newUser);
    } 
    public async Task<Post> AddEditPost(Post newPost)
    {
        return await _PostService.AddEditPost(newPost);
    } 
    public async Task<Notification> AddEditNotification(Notification newNotification)
    {
        return await _NotificationService.AddEditNotification(newNotification);
    } 
   
}
