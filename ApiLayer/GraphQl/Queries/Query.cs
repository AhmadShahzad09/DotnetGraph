
using Posts_graphql.Application.Services;
using Posts_graphql.Domain.Models;

namespace posts_graphql.api.Query;
public class Query
{
    private readonly UserService _UserService;
    private readonly PostService _PostService;
    private readonly NotificationService _NotificationService;

    public Query(UserService userService ,  PostService postService ,  NotificationService notificationService )
    {
        _UserService = userService;
        _PostService = postService;
        _NotificationService = notificationService;
    }

   public  async  Task<List<UserProfile>> GetAllUser() =>  await _UserService.GetAllUsers();

   public  async  Task<UserProfile> LoginUser(string email , string password) =>  await _UserService.LoginUserAsync(email,password);
   public  async  Task<bool?> IsUserExistsAsync(string email ) =>  await _UserService.IsUserExistsAsync(email);

   public async  Task<List<Post>> GetAllPost() => await  _PostService.GetPost(null);
   public async  Task<List<Post>> GetPostById(int PostId) => await  _PostService.GetPost(PostId);
   public async  Task<List<Notification>> GetAllNotification() => await  _NotificationService.GetNotification(null);
   public async  Task<List<Notification>> GetNotificationById(int NotificationId) => await  _NotificationService.GetNotification(NotificationId);

}